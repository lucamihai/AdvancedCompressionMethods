using AdvancedCompressionMethods.DI;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
using ScottPlot;

namespace AdvancedCompressionMethods.UserControls
{
    public partial class NearLosslessPredictorUserControl : UserControl
    {
        private readonly INearLosslessPredictiveEncoder nearLosslessPredictiveEncoder;
        private readonly INearLosslessPredictiveDecoder nearLosslessPredictiveDecoder;
        private ImageMatrices imageMatricesFromPreviousRun;
        private Plot plot;

        private Dictionary<RadioButton, NearLosslessPredictorType> predictorTypesRadioButtonsDictionary;
        private Dictionary<RadioButton, NearLosslessErrorMatrixSaveMode> saveModesRadioButtonsDictionary;

        private string filePathOriginalImage;
        private string filePathPredictedImage;
        private string filePathDecodedImage;

        public NearLosslessPredictorUserControl()
        {
            InitializeComponent();
            InitializePredictorTypesRadioButtonsDictionary();
            InitializeSaveModesRadioButtonsDictionary();
            InitializeHistogramArea();

            var serviceProvider = DependencyResolver.GetServices().BuildServiceProvider();
            nearLosslessPredictiveEncoder = serviceProvider.GetRequiredService<INearLosslessPredictiveEncoder>();
            nearLosslessPredictiveDecoder = serviceProvider.GetRequiredService<INearLosslessPredictiveDecoder>();
        }

        private void LoadImageClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse Bitmap files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "bmp",
                Filter = "Bitmap (*.bmp)|*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathOriginalImage = openFileDialog.FileName;

                using var fileStream = new FileStream(filePathOriginalImage, FileMode.Open);
                var bmp = new Bitmap(fileStream);
                pictureBoxOriginalImage.Image = bmp;
            }

            openFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void PredictClick(object sender, EventArgs e)
        {
            var options = GetOptions();
            var filePathEncodedImage = $"{filePathOriginalImage}.pre";

            if (File.Exists(filePathEncodedImage))
            {
                File.Delete(filePathEncodedImage);
            }

            nearLosslessPredictiveEncoder.Encode(filePathOriginalImage, filePathEncodedImage, options);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ShowErrorMatrixClick(object sender, EventArgs e)
        {
            var scale = numericUpDownErrorMatrixScale.Value;
            var bitmapErrorMatrix = new Bitmap(256, 256);

            for (var row = 0; row < 256; row++)
            {
                for (var column = 0; column < 256; column++)
                {
                    var code = Math.Abs(128 + imageMatricesFromPreviousRun.Errors[row, column] * scale);
                    code = GetByteFromDecimal(code);
                    var codeByte = (byte)code;
                    bitmapErrorMatrix.SetPixel(row, column, Color.FromArgb(codeByte, codeByte, codeByte));
                }
            }

            pictureBoxErrorMatrix.Image = bitmapErrorMatrix;
        }

        private void LoadEncodedImageClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse Predicted files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "pre",
                Filter = "Predicted (*.pre)|*.pre",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathPredictedImage = openFileDialog.FileName;
            }

            openFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void DecodeClick(object sender, EventArgs e)
        {
            filePathDecodedImage = $"{filePathPredictedImage}.bmp";

            if (File.Exists(filePathDecodedImage))
            {
                File.Delete(filePathDecodedImage);
            }

            imageMatricesFromPreviousRun = nearLosslessPredictiveDecoder.Decode(filePathPredictedImage, filePathDecodedImage);
            
            pictureBoxDecodedImage.Image = FromFile(filePathDecodedImage);
        }

        private static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);

            return img;
        }

        private void SaveDecodedClick(object sender, EventArgs e)
        {

        }

        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {
            plot.Clear();
            plot.YAxis.Label("Frequency");
            plot.XAxis.Label("Value");
            plot.SetAxisLimits(yMin: 0);

            var frequencies = GetFrequencies();

            for (var index = -256; index < 256; index++)
            {
                plot.AddLine(x1: index, y1: 0, x2: index, y2: frequencies[index], Color.Black, lineWidth: 1f);

                if (frequencies[index] < 1)
                {
                    continue;
                }

                if (frequencies[index] > 0)
                {

                }

                if (Math.Abs(frequencies[index]) > 255)
                {
                    continue;
                }
                
            }
        }

        private void UpdateButtonsEnabledProperty()
        {

        }

        private NearLosslessOptions GetOptions()
        {
            var checkedPredictionRadioButton = panelImagePredictorSelection
                .Controls
                .OfType<RadioButton>()
                .First(x => x.Checked);

            var checkedSaveModeRadioButton = panelSaveModeSelection
                .Controls
                .OfType<RadioButton>()
                .First(x => x.Checked);

            return new NearLosslessOptions
            {
                AcceptedError = (int)numericUpDownAcceptedError.Value,
                PredictorType = predictorTypesRadioButtonsDictionary[checkedPredictionRadioButton],
                SaveMode = saveModesRadioButtonsDictionary[checkedSaveModeRadioButton],
                PredictionLowerLimit = (byte)numericUpDownDomainMinValue.Value,
                PredictionUpperLimit = (byte)numericUpDownDomainMaxValue.Value
            };
        }

        private Dictionary<int, int> GetFrequencies()
        {
            var frequencies = new Dictionary<int, int>();

            for (var i = -256; i < 256; i++)
            {
                frequencies.Add(i, 0);
            }

            if (radioButtonHistogramOriginal.Checked)
            {
                var bitmap = (Bitmap)pictureBoxOriginalImage.Image;

                for (var row = 0; row < 256; row++)
                {
                    for (var column = 0; column < 256; column++)
                    {
                        var code = bitmap.GetPixel(row, column).R;
                        frequencies[code]++;
                    }
                }
            }

            if (radioButtonHistogramErrorMatrix.Checked)
            {
                for (var row = 0; row < 256; row++)
                {
                    for (var column = 0; column < 256; column++)
                    {
                        var code = imageMatricesFromPreviousRun.DequantizedErrors[row, column];
                        frequencies[code]++;
                    }
                }
            }

            if (radioButtonHistogramDecoded.Checked)
            {
                for (var row = 0; row < 256; row++)
                {
                    for (var column = 0; column < 256; column++)
                    {
                        var code = imageMatricesFromPreviousRun.Decoded[row, column];
                        frequencies[code]++;
                    }
                }
            }

            return frequencies;
        }

        private void InitializePredictorTypesRadioButtonsDictionary()
        {
            predictorTypesRadioButtonsDictionary = new Dictionary<RadioButton, NearLosslessPredictorType>
            {
                {radioButtonImagePredictor0, NearLosslessPredictorType.Predictor0 },
                {radioButtonImagePredictor1, NearLosslessPredictorType.Predictor1 },
                {radioButtonImagePredictor2, NearLosslessPredictorType.Predictor2 },
                {radioButtonImagePredictor3, NearLosslessPredictorType.Predictor3 },
                {radioButtonImagePredictor4, NearLosslessPredictorType.Predictor4 },
                {radioButtonImagePredictor5, NearLosslessPredictorType.Predictor5 },
                {radioButtonImagePredictor6, NearLosslessPredictorType.Predictor6 },
                {radioButtonImagePredictor7, NearLosslessPredictorType.Predictor7 },
                {radioButtonImagePredictor8, NearLosslessPredictorType.Predictor8 }
            };
        }

        private void InitializeSaveModesRadioButtonsDictionary()
        {
            saveModesRadioButtonsDictionary = new Dictionary<RadioButton, NearLosslessErrorMatrixSaveMode>
            {
                {radioButtonSaveMode9Bits, NearLosslessErrorMatrixSaveMode.FixedNumberOfBits },
                {radioButtonSaveModeJpegTable, NearLosslessErrorMatrixSaveMode.JpegTable },
                {radioButtonSaveModeArithmetic, NearLosslessErrorMatrixSaveMode.ArithmeticCoding }
            };
        }

        private void InitializeHistogramArea()
        {
            var formsPlot = new FormsPlot();
            formsPlot.Width = panelHistogram.Width;
            formsPlot.Height = panelHistogram.Height;
            
            panelHistogram.Controls.Add(formsPlot);

            plot = formsPlot.Plot;
            plot.YAxis.Label("Frequency");
            plot.XAxis.Label("Value");
            plot.SetAxisLimits(yMin: 0);
        }

        private static byte GetByteFromDecimal(decimal value)
        {
            if (value < 0)
            {
                return 0;
            }

            if (value > 255)
            {
                return 255;
            }

            return (byte)value;
        }
    }
}

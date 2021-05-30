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

namespace AdvancedCompressionMethods.UserControls
{
    public partial class NearLosslessPredictorUserControl : UserControl
    {
        private readonly INearLosslessPredictiveEncoder nearLosslessPredictiveEncoder;
        private readonly INearLosslessPredictiveDecoder nearLosslessPredictiveDecoder;
        private ImageMatrices imageMatricesFromPreviousRun;
        
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
            filePathDecodedImage = $"{filePathDecodedImage}.bmp";

            if (File.Exists(filePathDecodedImage))
            {
                File.Delete(filePathDecodedImage);
            }

            imageMatricesFromPreviousRun = nearLosslessPredictiveDecoder.Decode(filePathPredictedImage, filePathDecodedImage);

            using var fileStream = new FileStream(filePathDecodedImage, FileMode.Open);
            var bmp = new Bitmap(fileStream);
            pictureBoxDecodedImage.Image = bmp;
        }

        private void SaveDecodedClick(object sender, EventArgs e)
        {

        }

        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {
            pictureBoxHistogram.Image = new Bitmap(256, 256);
            var histogramImage = pictureBoxHistogram.Image;

            using (var graphics = Graphics.FromImage(histogramImage))
            {
                var pen = new Pen(Color.Black, 1);
                var frequencies = GetFrequencies();
                var cv1 = frequencies.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


                for (var index = -256; index < 256; index++)
                {
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

                    var x = index + 256;
                    var p1 = new Point(x, histogramImage.Height - 1);
                    var p2 = new Point(x, histogramImage.Height - 1 - frequencies[index]);

                    graphics.DrawLine(pen, p1, p2);
                }
            }

            pictureBoxHistogram.Refresh();
            pictureBoxHistogram.Invalidate();
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
                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        var code = imageMatricesFromPreviousRun.Errors[row, column];
                        frequencies[code]++;
                    }
                }
            }

            if (radioButtonHistogramDecoded.Checked)
            {
                var bitmap = (Bitmap)pictureBoxDecodedImage.Image;

                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        //var code = bitmap.GetPixel(row, column).R;
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

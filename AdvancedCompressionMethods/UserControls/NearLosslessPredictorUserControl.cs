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
                    //var code = Math.Abs(128 + imagePredictionEncoder.ErrorMatrix[row, column] * scale);
                    //code = GetByteFromDecimal(code);
                    //var codeByte = (byte)code;
                    //bitmapErrorMatrix.SetPixel(row, column, Color.FromArgb(codeByte, codeByte, codeByte));
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

            nearLosslessPredictiveDecoder.Decode(filePathPredictedImage, filePathDecodedImage);

            using var fileStream = new FileStream(filePathDecodedImage, FileMode.Open);
            var bmp = new Bitmap(fileStream);
            pictureBoxDecodedImage.Image = bmp;
        }

        private void SaveDecodedClick(object sender, EventArgs e)
        {

        }

        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {
            //pictureBoxHistogram.Image = new Bitmap(256, 256);
            //var histogramImage = pictureBoxHistogram.Image;

            //using (var graphics = Graphics.FromImage(histogramImage))
            //{
            //    var pen = new Pen(Color.Black, 1);
            //    var frequencies = GetFrequencies();

            //    for (int index = -256; index < 256; index++)
            //    {
            //        if (frequencies[index] < 1)
            //        {
            //            continue;
            //        }

            //        if (frequencies[index] > 0)
            //        {

            //        }

            //        var x = index + 256;
            //        var p1 = new Point(x, histogramImage.Height - 1);
            //        var p2 = new Point(x, histogramImage.Height - 1 - frequencies[index]);

            //        graphics.DrawLine(pen, p1, p2);
            //    }
            //}

            //pictureBoxHistogram.Refresh();
            //pictureBoxHistogram.Invalidate();
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
                {radioButtonSaveModeArithmetic, NearLosslessErrorMatrixSaveMode.ArithmeticCoding },
            };
        }
    }
}

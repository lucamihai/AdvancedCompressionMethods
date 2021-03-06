﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AdvancedCompressionMethods.DI;
using AdvancedCompressionMethods.WaveletCoding.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCompressionMethods.UserControls
{
    public partial class WaveletCoderUserControl : UserControl
    {
        private string filePathOriginalImage;
        private readonly IWaveletCoder waveletCoder;

        public WaveletCoderUserControl()
        {
            InitializeComponent();

            var serviceProvider = DependencyResolver.GetServices().BuildServiceProvider();
            waveletCoder = serviceProvider.GetRequiredService<IWaveletCoder>();

            GenerateButtons();
        }

        private void buttonLoadOriginalImage_Click(object sender, EventArgs e)
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

                var imageCodes = GetImageCodesOrThrow(bmp);
                waveletCoder.Load(imageCodes);

                pictureBoxOriginalImage.Image = bmp;
                pictureBoxWaveletImage.Image = new Bitmap(bmp);
            }
        }

        private static double[,] GetImageCodesOrThrow(Bitmap image)
        {
            if (image.Width != 512 || image.Height != 512)
            {
                throw new ArgumentException("Image needs to be 512x512");
            }

            var imageCodes = new double[image.Width, image.Height];

            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    imageCodes[i, j] = image.GetPixel(i, j).R;
                }
            }

            return imageCodes;
        }

        private void UpdateWaveletImage()
        {
            var imageCodes = waveletCoder.ImageCodes;
            var width = imageCodes.GetLength(0);
            var height = imageCodes.GetLength(1);

            var highlightStartPositionX = (int)numericUpDownHighlightX.Value;
            var highlightStartPositionY = (int)numericUpDownHighlightY.Value;
            var highlightScale = numericUpDownHighlightScale.Value;
            var highlightOffset = (int)numericUpDownHighlighOffset.Value;

            var image = new Bitmap(512, 512);
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var pixelIntensity = (byte) Math.Abs(Math.Round(imageCodes[i, j]));

                    if (i >= highlightStartPositionX || j >= highlightStartPositionY )
                    {
                        var newIntensity = pixelIntensity * highlightScale + highlightOffset;
                        pixelIntensity = GetByteFromDecimal(newIntensity);
                    }

                    image.SetPixel(i, j, Color.FromArgb(pixelIntensity, pixelIntensity, pixelIntensity));
                }
            }

            pictureBoxWaveletImage.Image.Dispose();
            pictureBoxWaveletImage.Image = new Bitmap(image);
            pictureBoxWaveletImage.Invalidate();
        }

        private void buttonAnalysisAllTheWay_Click(object sender, EventArgs e)
        {
            var levels = (int)numericUpDownLevelsAllTheWay.Value;

            for (var i = 0; i < levels; i++)
            {
                waveletCoder.ApplyHorizontalAnalysis(i + 1);
                waveletCoder.ApplyVerticalAnalysis(i + 1);

                HalveNumericUpDownValue(numericUpDownHighlightX);
                HalveNumericUpDownValue(numericUpDownHighlightY);
            }

            UpdateWaveletImage();
        }

        private void buttonSynthesisAllTheWay_Click(object sender, EventArgs e)
        {
            var levels = (int)numericUpDownLevelsAllTheWay.Value;

            for (var i = 0; i < levels; i++)
            {
                waveletCoder.ApplyVerticalSynthesis(levels - i);
                waveletCoder.ApplyHorizontalSynthesis(levels - i);

                DoubleNumericUpDownValue(numericUpDownHighlightX);
                DoubleNumericUpDownValue(numericUpDownHighlightY);
            }

            UpdateWaveletImage();
        }

        private void buttonTestErrors_Click(object sender, EventArgs e)
        {
            // TODO: Ensure matrices have equal sizes
            var originalImageAsBitmap = new Bitmap(pictureBoxOriginalImage.Image);
            var originalImageCodes = GetImageCodesOrThrow(originalImageAsBitmap);
            var waveletImageCodes = waveletCoder.ImageCodes;

            var minError = double.MaxValue;
            var maxError = double.MinValue;

            for (var i = 0; i < originalImageCodes.GetLength(0); i++)
            {
                for (var j = 0; j < originalImageCodes.GetLength(1); j++)
                {
                    var waveletCode = waveletImageCodes[i, j];
                    var originalCode = originalImageCodes[i, j];
                    var currentError = waveletCode - originalCode;

                    if (currentError < minError)
                    {
                        minError = currentError;
                    }

                    if (currentError > maxError)
                    {
                        maxError = currentError;
                    }
                }
            }

            textBoxMinError.Text = minError.ToString("N6");
            textBoxMaxError.Text = maxError.ToString("N6");
        }

        private void buttonLoadWaveletImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse Wavelet files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "wvl",
                Filter = "Wavelet (*.wvl)|*.wvl",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathOriginalImage = openFileDialog.FileName;

                using var fileStream = new FileStream(filePathOriginalImage, FileMode.Open);
                using var binaryReader = new BinaryReader(fileStream);

                var width = binaryReader.ReadInt32();
                var height = binaryReader.ReadInt32();

                var imageCodes = new double[width, height];

                for (var i = 0; i < width; i++)
                {
                    for (var j = 0; j < height; j++)
                    {
                        imageCodes[i, j] = binaryReader.ReadDouble();
                    }
                }
                
                waveletCoder.Load(imageCodes);
                UpdateWaveletImage();
            }
        }

        private void buttonSaveWaveletImage_Click(object sender, EventArgs e)
        {
            var filepathWaveletImage = $"{filePathOriginalImage}.wvl";
            using var fileStream = new FileStream(filepathWaveletImage, FileMode.Create);
            using var binaryWriter = new BinaryWriter(fileStream);

            var imageCodes = waveletCoder.ImageCodes;
            var width = imageCodes.GetLength(0);
            var height = imageCodes.GetLength(1);

            binaryWriter.Write(width);
            binaryWriter.Write(height);

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    binaryWriter.Write(imageCodes[i, j]);
                }
            }
        }

        private void buttonRedrawWavelet_Click(object sender, EventArgs e)
        {
            UpdateWaveletImage();
        }

        private void DoubleNumericUpDownValue(NumericUpDown numericUpDown)
        {
            var currentValue = numericUpDown.Value;
            var newValue = currentValue * 2;
            numericUpDown.Value = newValue > numericUpDown.Maximum
                ? currentValue
                : newValue;
        }

        private void HalveNumericUpDownValue(NumericUpDown numericUpDown)
        {
            var currentValue = numericUpDown.Value;
            var newValue = currentValue / 2;
            numericUpDown.Value = newValue < numericUpDown.Minimum
                ? currentValue
                : newValue;
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

        private void GenerateButtons()
        {
            GenerateButtonsForPanel(panelLevel1, 1);
            GenerateButtonsForPanel(panelLevel2, 2);
            GenerateButtonsForPanel(panelLevel3, 3);
            GenerateButtonsForPanel(panelLevel4, 4);
            GenerateButtonsForPanel(panelLevel5, 5);
        }

        private void GenerateButtonsForPanel(Panel panel, int level)
        {
            var size = new Size(58, 22);
            var horizontalAnalysisLocation = new Point(18, 35);
            var verticalAnalysisLocation = new Point(18, 53);
            var horizontalSynthesisLocation = new Point(82, 35);
            var verticalSynthesisLocation = new Point(82, 53);

            var horizontalAnalysisButton = new Button();
            horizontalAnalysisButton.Text = "H";
            horizontalAnalysisButton.Size = size;
            horizontalAnalysisButton.Location = horizontalAnalysisLocation;
            horizontalAnalysisButton.BackColor = Color.LightGray;
            horizontalAnalysisButton.Click += delegate(object? sender, EventArgs args)
            {
                waveletCoder.ApplyHorizontalAnalysis(level);
                HalveNumericUpDownValue(numericUpDownHighlightX);
                UpdateWaveletImage();
            };

            var verticalAnalysisButton = new Button();
            verticalAnalysisButton.Text = "V";
            verticalAnalysisButton.Size = size;
            verticalAnalysisButton.Location = verticalAnalysisLocation;
            verticalAnalysisButton.BackColor = Color.LightGray;
            verticalAnalysisButton.Click += delegate (object? sender, EventArgs args)
            {
                waveletCoder.ApplyVerticalAnalysis(level);
                HalveNumericUpDownValue(numericUpDownHighlightY);
                UpdateWaveletImage();
            };

            var horizontalSynthesisButton = new Button();
            horizontalSynthesisButton.Text = "H";
            horizontalSynthesisButton.Size = size;
            horizontalSynthesisButton.Location = horizontalSynthesisLocation;
            horizontalSynthesisButton.BackColor = Color.LightGray;
            horizontalSynthesisButton.Click += delegate (object? sender, EventArgs args)
            {
                waveletCoder.ApplyHorizontalSynthesis(level);
                DoubleNumericUpDownValue(numericUpDownHighlightX);
                UpdateWaveletImage();
            };

            var verticalSynthesisButton = new Button();
            verticalSynthesisButton.Text = "V";
            verticalSynthesisButton.Size = size;
            verticalSynthesisButton.Location = verticalSynthesisLocation;
            verticalSynthesisButton.BackColor = Color.LightGray;
            verticalSynthesisButton.Click += delegate (object? sender, EventArgs args)
            {
                waveletCoder.ApplyVerticalSynthesis(level);
                DoubleNumericUpDownValue(numericUpDownHighlightY);
                UpdateWaveletImage();
            };

            panel.Controls.Add(horizontalAnalysisButton);
            panel.Controls.Add(verticalAnalysisButton);
            panel.Controls.Add(horizontalSynthesisButton);
            panel.Controls.Add(verticalSynthesisButton);
        }
    }
}

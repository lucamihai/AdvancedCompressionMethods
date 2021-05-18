using System;
using System.Drawing;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding
{
    public class NearLosslessPredictiveEncoder : INearLosslessPredictiveEncoder
    {
        private readonly IFileReader fileReader;
        private readonly IFileWriter fileWriter;

        public NearLosslessPredictiveEncoder(IFileReader fileReader, IFileWriter fileWriter)
        {
            this.fileReader = fileReader;
            this.fileWriter = fileWriter;
        }

        public void Encode(string sourceFilepath, string destinationFilepath, NearLosslessOptions nearLosslessOptions)
        {
            var image = GetImageOrThrow(sourceFilepath);
            var imageMatrices = new ImageMatrices(image);

            PredictionMatrixHelper.SetImageMatrices(imageMatrices, nearLosslessOptions);

            fileReader.Open(sourceFilepath);
            fileWriter.Open(destinationFilepath);

            fileReader.Close();
            fileWriter.Close();

            throw new System.NotImplementedException();
        }

        private static Bitmap GetImageOrThrow(string sourceFilepath)
        {
            if (string.IsNullOrEmpty(sourceFilepath))
            {
                throw new ArgumentException(nameof(sourceFilepath));
            }

            if (!sourceFilepath.EndsWith(".bmp"))
            {
                throw new ArgumentException("Only .bmp images are accepted");
            }

            var image = new Bitmap(sourceFilepath);

            if (image.Size.Width != 256 || image.Size.Height != 256)
            {
                throw new ArgumentException("Image must be 256x256");
            }

            return image;
        }
    }
}
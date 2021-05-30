using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding
{
    public class NearLosslessPredictiveDecoder : INearLosslessPredictiveDecoder
    {
        private readonly IFileReader fileReader;
        private readonly IFileWriter fileWriter;

        public NearLosslessPredictiveDecoder(IFileReader fileReader, IFileWriter fileWriter)
        {
            this.fileReader = fileReader;
            this.fileWriter = fileWriter;
        }

        public ImageMatrices Decode(string sourceFilepath, string destinationFilepath)
        {
            fileReader.Open(sourceFilepath);
            fileWriter.Open(destinationFilepath);

            CopyBitmapHeader();
            var usedOptions = GetOptions();
            var errorMatrixReader = NearLosslessErrorMatrixReaderSelector.GetErrorMatrixReader(usedOptions.SaveMode);
            var quantizedErrorMatrix = errorMatrixReader.ReadErrorMatrix(fileReader);
            var imageMatrices = ErrorMatrixHelper.GetImageMatricesFromQuantizedErrorMatrix(quantizedErrorMatrix, usedOptions);
            WriteImageCodes(imageMatrices.Decoded);

            fileReader.Close();
            fileWriter.Close();

            return imageMatrices;
        }

        private void CopyBitmapHeader()
        {
            for (var index = 0; index < 1078; index++)
            {
                var currentByte = fileReader.ReadBits(8);
                fileWriter.WriteValueOnBits(currentByte, 8);
            }
        }

        private NearLosslessOptions GetOptions()
        {
            var bitsPredictorType = fileReader.ReadBits(4);
            var bitsAcceptedError = fileReader.ReadBits(4);
            var bitsSaveMode = fileReader.ReadBits(3);
            var bitsLowerLimit = fileReader.ReadBits(8);
            var bitsUpperLimit = fileReader.ReadBits(8);

            return new NearLosslessOptions
            {
                PredictorType = (NearLosslessPredictorType)bitsPredictorType,
                AcceptedError = (int)bitsAcceptedError,
                SaveMode = (NearLosslessErrorMatrixSaveMode)bitsSaveMode,
                PredictionLowerLimit = (byte)bitsLowerLimit,
                PredictionUpperLimit = (byte)bitsUpperLimit
            };
        }

        private void WriteImageCodes(byte[,] imageCodes)
        {
            for (var row = 255; row >= 0; row--)
            {
                for (var column = 0; column < 256; column++)
                {
                    fileWriter.WriteValueOnBits(imageCodes[column, row], 8);
                }
            }
        }
    }
}
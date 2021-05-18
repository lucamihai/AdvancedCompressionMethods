using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
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

        public void Decode(string sourceFilepath, string destinationFilepath)
        {
            fileReader.Open(sourceFilepath);
            fileWriter.Open(destinationFilepath);

            CopyBitmapHeader();
            var usedOptions = GetOptions();

            fileReader.Close();
            fileWriter.Close();

            throw new System.NotImplementedException();
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
            var bitsSaveMode = fileReader.ReadBits(2);

            return new NearLosslessOptions
            {
                PredictorType = (NearLosslessPredictorType)bitsPredictorType,
                AcceptedError = (int)bitsAcceptedError,
                SaveMode = (NearLosslessErrorMatrixSaveMode)bitsSaveMode
            };
        }
    }
}
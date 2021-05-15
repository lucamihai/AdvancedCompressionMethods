using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
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

        public void Encode(string sourceFilepath, string destinationFilepath, NearLosslessPredictor predictor)
        {
            fileReader.Open(sourceFilepath);
            fileWriter.Open(destinationFilepath);

            fileReader.Close();
            fileWriter.Close();

            throw new System.NotImplementedException();
        }
    }
}
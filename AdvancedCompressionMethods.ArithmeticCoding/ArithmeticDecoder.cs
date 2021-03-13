using AdvancedCompressionMethods.ArithmeticCoding.Interfaces;
using AdvancedCompressionMethods.FileOperations.Interfaces;

namespace AdvancedCompressionMethods.ArithmeticCoding
{
    public class ArithmeticDecoder : IArithmeticDecoder
    {
        private readonly IFileReader fileReader;
        private readonly IFileWriter fileWriter;

        public ArithmeticDecoder(IFileReader fileReader, IFileWriter fileWriter)
        {
            this.fileReader = fileReader;
            this.fileWriter = fileWriter;
        }

        public void DecodeFile(string sourceFilepath, string destinationFilepath)
        {
            fileReader.Open(sourceFilepath);
            fileWriter.Open(destinationFilepath);

            throw new System.NotImplementedException();
        }
    }
}
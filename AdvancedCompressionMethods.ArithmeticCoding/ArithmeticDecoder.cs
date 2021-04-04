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

            while (!fileReader.ReachedEndOfFile)
            {
                var cv = fileReader.ReadBits(8);
                fileWriter.WriteValueOnBits(cv, 8);
            }

            fileReader.Close();
            fileWriter.Close();

            //throw new System.NotImplementedException();
        }
    }
}
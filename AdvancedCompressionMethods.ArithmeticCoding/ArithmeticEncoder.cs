using AdvancedCompressionMethods.ArithmeticCoding.Interfaces;
using AdvancedCompressionMethods.FileOperations.Interfaces;

namespace AdvancedCompressionMethods.ArithmeticCoding
{
    public class ArithmeticEncoder : IArithmeticEncoder
    {
        private readonly IFileReader fileReader;
        private readonly IFileWriter fileWriter;

        public ArithmeticEncoder(IFileReader fileReader, IFileWriter fileWriter)
        {
            this.fileReader = fileReader;
            this.fileWriter = fileWriter;
        }

        public void EncodeFile(string sourceFilepath, string destinationFilepath)
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
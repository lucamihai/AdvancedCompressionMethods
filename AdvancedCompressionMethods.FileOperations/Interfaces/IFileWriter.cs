namespace AdvancedCompressionMethods.FileOperations.Interfaces
{
    public interface IFileWriter
    {
        void Open(string filepath);
        void Close();

        void WriteBit(bool bitValue);
        void WriteValueOnBits(uint value, byte numberOfBits);
        void Flush();
    }
}
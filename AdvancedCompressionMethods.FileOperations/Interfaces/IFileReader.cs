namespace AdvancedCompressionMethods.FileOperations.Interfaces
{
    public interface IFileReader
    {
        string FilePath { get; }
        bool ReachedEndOfFile { get; }
        long BitsLeft { get; }

        void Open(string filepath);
        void Close();
        void Reset();

        bool ReadBit();
        uint ReadBits(byte numberOfBits);
    }
}
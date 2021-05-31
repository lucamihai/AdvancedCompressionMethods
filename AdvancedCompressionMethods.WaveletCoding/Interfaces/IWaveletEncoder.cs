namespace AdvancedCompressionMethods.WaveletCoding.Interfaces
{
    public interface IWaveletEncoder
    {
        void Encode(string sourceFilepath, string destinationFilepath);
    }
}
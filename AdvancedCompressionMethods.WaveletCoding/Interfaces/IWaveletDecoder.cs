namespace AdvancedCompressionMethods.WaveletCoding.Interfaces
{
    public interface IWaveletDecoder
    {
        void Decode(string sourceFilepath, string destinationFilepath);
    }
}
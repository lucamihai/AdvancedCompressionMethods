using AdvancedCompressionMethods.WaveletCoding.Interfaces;
using AdvancedCompressionMethods.WaveletCoding.Interfaces.Helpers;

namespace AdvancedCompressionMethods.WaveletCoding
{
    public class WaveletCoder : IWaveletCoder
    {
        public double[,] ImageCodes { get; private set; }

        private readonly IWaveletAnalyzer waveletAnalyzer;
        private readonly IWaveletSynthesizer waveletSynthesizer;

        public WaveletCoder(IWaveletAnalyzer waveletAnalyzer, IWaveletSynthesizer waveletSynthesizer)
        {
            this.waveletAnalyzer = waveletAnalyzer;
            this.waveletSynthesizer = waveletSynthesizer;
        }

        public void Load(double[,] imageCodes)
        {
            ImageCodes = imageCodes;
        }

        public void ApplyHorizontalAnalysis(int level)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyVerticalAnalysis(int level)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyHorizontalSynthesis(int level)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyVerticalSynthesis(int level)
        {
            throw new System.NotImplementedException();
        }
    }
}
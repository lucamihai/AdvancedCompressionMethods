namespace AdvancedCompressionMethods.WaveletCoding.Interfaces
{
    public interface IWaveletCoder
    {
        double[,] ImageCodes { get; }

        void Load(double[,] imageCodes);
        
        void ApplyHorizontalAnalysis(int level);
        void ApplyVerticalAnalysis(int level);
        void ApplyHorizontalSynthesis(int level);
        void ApplyVerticalSynthesis(int level);
    }
}
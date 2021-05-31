using System.Collections.Generic;
using AdvancedCompressionMethods.WaveletCoding.Entities;

namespace AdvancedCompressionMethods.WaveletCoding.Interfaces.Helpers
{
    public interface IWaveletSynthesizer
    {
        List<double> GetSynthesis(WaveletAnalysisCollection analysisCollection);
    }
}
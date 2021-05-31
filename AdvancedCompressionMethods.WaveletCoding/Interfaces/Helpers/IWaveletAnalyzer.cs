using System.Collections.Generic;
using AdvancedCompressionMethods.WaveletCoding.Entities;

namespace AdvancedCompressionMethods.WaveletCoding.Interfaces.Helpers
{
    public interface IWaveletAnalyzer
    {
        WaveletAnalysisCollection GetAnalysis(List<byte> values);
    }
}
using System.Collections.Generic;

namespace AdvancedCompressionMethods.WaveletCoding.Entities
{
    public class WaveletAnalysisCollection
    {
        public WaveletAnalysisCollection()
        {
            RearrangedLow = new List<double>();
            RearrangedHigh = new List<double>();
        }

        public List<double> RearrangedLow { get; set; }
        public List<double> RearrangedHigh { get; set; }
    }
}
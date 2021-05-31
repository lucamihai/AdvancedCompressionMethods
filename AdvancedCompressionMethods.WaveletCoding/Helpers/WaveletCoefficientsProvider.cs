using System.Collections.Generic;

namespace AdvancedCompressionMethods.WaveletCoding.Helpers
{
    // TODO: Make this a service instead of static
    public static class WaveletCoefficientsProvider
    {
        // TODO: Consider extracting into configuration file/s
        public static List<double> GetAnalysisLowCoefficients()
        {
            return new List<double>
            {
                0.026748757411,
                -0.016864118443,
                -0.078223266529,
                0.266864118443,
                0.602949018236,
                0.266864118443,
                -0.078223266529,
                -0.016864118443,
                0.026748757411
            };
        }

        // TODO: Consider extracting into configuration file/s
        public static List<double> GetAnalysisHighCoefficients()
        {
            return new List<double>
            {
                0.000000000000,
                0.091271763114,
                -0.057543526229,
                -0.591271763114,
                1.115087052457,
                -0.591271763114,
                -0.057543526229,
                0.091271763114,
                0.000000000000
            };
        }
    }
}
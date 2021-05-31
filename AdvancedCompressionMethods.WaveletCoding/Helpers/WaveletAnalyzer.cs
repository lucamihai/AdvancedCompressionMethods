using System;
using System.Collections.Generic;
using AdvancedCompressionMethods.WaveletCoding.Entities;
using AdvancedCompressionMethods.WaveletCoding.Interfaces.Helpers;

namespace AdvancedCompressionMethods.WaveletCoding.Helpers
{
    public class WaveletAnalyzer : IWaveletAnalyzer
    {
        private List<double> analysisLowCoefficients;
        private List<double> analysisHighCoefficients;

        public WaveletAnalyzer()
        {
            InitializeCoefficients();
        }

        public WaveletAnalysisCollection GetAnalysis(List<double> values)
        {
            var analysisCollection = new WaveletAnalysisCollection();
            var formattedValues = WaveletValuesListMirroringHelper.GetValuesListWithMirroredExtremities(values);

            for (var i = 0; i < values.Count; i++)
            {
                var low = 0d;
                var high = 0d;

                for (var j = 0; j < 9; j++)
                {
                    low += formattedValues[i + j] * analysisLowCoefficients[j];
                    high += formattedValues[i + j] * analysisHighCoefficients[j];
                }

                if (i % 2 == 0)
                {
                    low = Math.Round(low, 6);
                    analysisCollection.RearrangedLow.Add(low);
                }
                else
                {
                    high = Math.Round(high, 6);
                    analysisCollection.RearrangedHigh.Add(high);
                }
            }

            return analysisCollection;
        }

        private void InitializeCoefficients()
        {
            analysisLowCoefficients = WaveletCoefficientsProvider.GetAnalysisLowCoefficients();
            analysisHighCoefficients = WaveletCoefficientsProvider.GetAnalysisHighCoefficients();
        }
    }
}
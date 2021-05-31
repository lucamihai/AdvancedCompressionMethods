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

        public WaveletAnalysisCollection GetAnalysis(List<byte> values)
        {
            var analysisCollection = new WaveletAnalysisCollection();
            var formattedValues = GetValuesListWithMirroredExtremities(values);

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

        // TODO: Could be extracted into a helper
        private static List<byte> GetValuesListWithMirroredExtremities(List<byte> values)
        {
            // TODO: Maybe handle cases when values.Count < 4?

            var newValues = new List<byte>();

            for (var i = 4; i >= 1; i--)
            {
                newValues.Add(values[i]);
            }

            newValues.AddRange(values);

            var indexOfLastElement = values.Count - 1;
            for (var i = 0; i < 4; i++)
            {
                newValues.Add(values[indexOfLastElement -1 - i]);
            }

            return newValues;
        }

        private void InitializeCoefficients()
        {
            analysisLowCoefficients = WaveletCoefficientsProvider.GetAnalysisLowCoefficients();
            analysisHighCoefficients = WaveletCoefficientsProvider.GetAnalysisHighCoefficients();
        }
    }
}
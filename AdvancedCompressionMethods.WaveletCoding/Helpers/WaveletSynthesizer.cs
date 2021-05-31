using System;
using System.Collections.Generic;
using AdvancedCompressionMethods.WaveletCoding.Entities;
using AdvancedCompressionMethods.WaveletCoding.Interfaces.Helpers;

namespace AdvancedCompressionMethods.WaveletCoding.Helpers
{
    public class WaveletSynthesizer : IWaveletSynthesizer
    {
        private List<double> synthesisLowCoefficients;
        private List<double> synthesisHighCoefficients;

        public WaveletSynthesizer()
        {
            InitializeCoefficients();
        }

        public List<double> GetSynthesis(WaveletAnalysisCollection analysisCollection)
        {
            var reconstructedValues = new List<double>();

            var scaledUpLow = UpscaleLow(analysisCollection.RearrangedLow);
            var scaledUpHigh = UpscaleHigh(analysisCollection.RearrangedHigh);

            var formattedLow = WaveletValuesListMirroringHelper.GetValuesListWithMirroredExtremities(scaledUpLow);
            var formattedHigh = WaveletValuesListMirroringHelper.GetValuesListWithMirroredExtremities(scaledUpHigh);

            for (var i = 0; i < analysisCollection.RearrangedLow.Count + analysisCollection.RearrangedHigh.Count; i++)
            {
                var low = 0d;
                var high = 0d;

                for (var j = 0; j < 9; j++)
                {
                    low += formattedLow[i + j] * synthesisLowCoefficients[j];
                    high += formattedHigh[i + j] * synthesisHighCoefficients[j];
                }

                reconstructedValues.Add(low + high);
            }

            return reconstructedValues;
        }

        private void InitializeCoefficients()
        {
            synthesisLowCoefficients = WaveletCoefficientsProvider.GetSynthesisLowCoefficients();
            synthesisHighCoefficients = WaveletCoefficientsProvider.GetSynthesisHighCoefficients();
        }

        private static List<double> UpscaleLow(List<double> values)
        {
            var scaledUpList = new List<double>();

            foreach (var value in values)
            {
                scaledUpList.Add(value);
                scaledUpList.Add(0);
            }

            return scaledUpList;
        }

        private static List<double> UpscaleHigh(List<double> values)
        {
            var scaledUpList = new List<double>();

            foreach (var value in values)
            {
                scaledUpList.Add(0);
                scaledUpList.Add(value);
            }

            return scaledUpList;
        }
    }
}
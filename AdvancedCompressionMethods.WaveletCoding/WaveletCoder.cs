using System.Collections.Generic;
using AdvancedCompressionMethods.WaveletCoding.Entities;
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
            for (var columnNumber = 0; columnNumber < ImageCodes.GetLength(1); columnNumber++)
            {
                var column = GetColumn(columnNumber);
                var columnAnalysis = waveletAnalyzer.GetAnalysis(column);
                CopyColumnAnalysis(columnAnalysis, columnNumber);
            }
        }

        public void ApplyVerticalAnalysis(int level)
        {
            for (var rowNumber = 0; rowNumber < ImageCodes.GetLength(0); rowNumber++)
            {
                var row = GetRow(rowNumber);
                var rowAnalysis = waveletAnalyzer.GetAnalysis(row);
                CopyRowAnalysis(rowAnalysis, rowNumber);
            }
        }

        public void ApplyHorizontalSynthesis(int level)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyVerticalSynthesis(int level)
        {
            throw new System.NotImplementedException();
        }

        private List<double> GetRow(int rowNumber)
        {
            var row = new List<double>();

            for (var columnNumber = 0; columnNumber < ImageCodes.GetLength(1); columnNumber++)
            {
                row.Add(ImageCodes[rowNumber, columnNumber]);
            }

            return row;
        }

        private List<double> GetColumn(int columnNumber)
        {
            var column = new List<double>();

            for (var rowNumber = 0; rowNumber < ImageCodes.GetLength(0); rowNumber++)
            {
                column.Add(ImageCodes[rowNumber, columnNumber]);
            }

            return column;
        }

        private void CopyRowAnalysis(WaveletAnalysisCollection analysisCollection, int rowNumber)
        {
            for (var column = 0; column < analysisCollection.RearrangedLow.Count; column++)
            {
                ImageCodes[rowNumber, column] = analysisCollection.RearrangedLow[column];
            }

            for (var column = analysisCollection.RearrangedLow.Count; column < analysisCollection.RearrangedHigh.Count; column++)
            {
                ImageCodes[rowNumber, column] = analysisCollection.RearrangedHigh[column];
            }
        }

        private void CopyColumnAnalysis(WaveletAnalysisCollection analysisCollection, int columnNumber)
        {
            for (var row = 0; row < analysisCollection.RearrangedLow.Count; row++)
            {
                ImageCodes[row, columnNumber] = analysisCollection.RearrangedLow[row];
            }

            for (var row = analysisCollection.RearrangedLow.Count; row < analysisCollection.RearrangedHigh.Count; row++)
            {
                ImageCodes[row, columnNumber] = analysisCollection.RearrangedHigh[row];
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
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
            for (var columnNumber = 0; columnNumber < ImageCodes.GetLength(1); columnNumber++)
            {
                var column = GetColumn(columnNumber);
                var columnForSynthesis = FormatForSynthesis(column);
                var columnSynthesis = waveletSynthesizer.GetSynthesis(columnForSynthesis);
                CopyColumnSynthesis(columnSynthesis, columnNumber);
            }
        }

        public void ApplyVerticalSynthesis(int level)
        {
            for (var rowNumber = 0; rowNumber < ImageCodes.GetLength(0); rowNumber++)
            {
                var row = GetRow(rowNumber);
                var rowForSynthesis = FormatForSynthesis(row);
                var rowSynthesis = waveletSynthesizer.GetSynthesis(rowForSynthesis);
                CopyRowSynthesis(rowSynthesis, rowNumber);
            }
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

        private WaveletAnalysisCollection FormatForSynthesis(List<double> values)
        {
            return new WaveletAnalysisCollection
            {
                RearrangedLow = values.Take(values.Count / 2).ToList(),
                RearrangedHigh = values.Skip(values.Count / 2).ToList()
            };
        }

        private void CopyRowAnalysis(WaveletAnalysisCollection analysisCollection, int rowNumber)
        {
            for (var columnNumber = 0; columnNumber < analysisCollection.RearrangedLow.Count; columnNumber++)
            {
                ImageCodes[rowNumber, columnNumber] = analysisCollection.RearrangedLow[columnNumber];
            }

            for (var columnNumber = 0; columnNumber < analysisCollection.RearrangedHigh.Count; columnNumber++)
            {
                ImageCodes[rowNumber, columnNumber + analysisCollection.RearrangedLow.Count] = analysisCollection.RearrangedHigh[columnNumber];
            }
        }

        private void CopyColumnAnalysis(WaveletAnalysisCollection analysisCollection, int columnNumber)
        {
            for (var rowNumber = 0; rowNumber < analysisCollection.RearrangedLow.Count; rowNumber++)
            {
                ImageCodes[rowNumber, columnNumber] = analysisCollection.RearrangedLow[rowNumber];
            }

            for (var rowNumber = 0; rowNumber < analysisCollection.RearrangedHigh.Count; rowNumber++)
            {
                ImageCodes[rowNumber + analysisCollection.RearrangedLow.Count, columnNumber] = analysisCollection.RearrangedHigh[rowNumber];
            }
        }

        private void CopyRowSynthesis(List<double> synthesis, int rowNumber)
        {
            for (var columnNumber = 0; columnNumber < synthesis.Count; columnNumber++)
            {
                ImageCodes[rowNumber, columnNumber] = synthesis[columnNumber];
            }
        }

        private void CopyColumnSynthesis(List<double> synthesis, int columnNumber)
        {
            for (var rowNumber = 0; rowNumber < synthesis.Count; rowNumber++)
            {
                ImageCodes[rowNumber, columnNumber] = synthesis[rowNumber];
            }
        }
    }
}
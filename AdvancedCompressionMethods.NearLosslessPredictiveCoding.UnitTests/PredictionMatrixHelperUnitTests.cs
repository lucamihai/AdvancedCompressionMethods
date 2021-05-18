using System.Diagnostics.CodeAnalysis;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PredictionMatrixHelperUnitTests
    {
        private int k;
        private INearLosslessPredictor predictor;
        private ImageMatrices imageMatrices;
        private ImageMatrices expectedImageMatrices;

        [TestMethod]
        public void TestThatSetImageMatricesSetsImageMatricesAsExpected1()
        {
            SetupCase1();

            PredictionMatrixHelper.SetImageMatrices(imageMatrices, predictor);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(expectedImageMatrices, imageMatrices).AreEqual);
        }

        private void SetupCase1()
        {
            k = 2;
            predictor = NearLosslessPredictorSelector.GetPredictor(NearLosslessPredictorType.Predictor4);
            imageMatrices = new ImageMatrices(4, 4);
            expectedImageMatrices = new ImageMatrices(4, 4);

            var imageCodes = new byte[,]
            {
                {7, 5, 2, 0},
                {2, 11, 1, 0},
                {15, 15, 15, 0},
                {1, 4, 14, 14}
            };

            var expectedPredictions = new byte[,]
            {
                {8, 8, 3, 3},
                {8, 0, 10, 0},
                {3, 15, 5, 15},
                {13, 5, 5, 0}
            };

            var expectedErrors = new int[,]
            {
                {-1, -3, -1, -3},
                {-6, 11, -9, 0},
                {12, 0, 10, -15},
                {-12, -1, 9, 14}
            };

            var expectedQuantizedErrors = new int[,]
            {
                {0, -1, 0, -1},
                {-1, 2, -2, 0},
                {2, 0, 2, -3},
                {-2, 0, 2, 3}
            };

            var expectedDequantizedErrors = new int[,]
            {
                {0, -5, 0, -5},
                {-5, 10, -10, 0},
                {10, 0, 10, -15},
                {-10, 0, 10, 15}
            };

            var expectedDecoded = new byte[,]
            {
                {8, 3, 3, 0},
                {3, 10, 0, 0},
                {13, 15, 15, 0},
                {3, 5, 15, 15}
            };

            CopyMatrix(imageCodes, imageMatrices.Codes);
            CopyMatrix(imageCodes, expectedImageMatrices.Codes);

            CopyMatrix(expectedPredictions, expectedImageMatrices.Predictions);
            CopyMatrix(expectedErrors, expectedImageMatrices.Errors);
            CopyMatrix(expectedQuantizedErrors, expectedImageMatrices.QuantizedErrors);
            CopyMatrix(expectedDequantizedErrors, expectedImageMatrices.DequantizedErrors);
            CopyMatrix(expectedDecoded, expectedImageMatrices.Decoded);
        }

        private static void CopyMatrix<T>(T[,] source, T[,] destination)
        {
            for (var row = 0; row < source.GetLength(0); row++)
            {
                for (var column = 0; column < source.GetLength(1); column++)
                {
                    destination[row, column] = source[row, column];
                }
            }
        }
    }
}

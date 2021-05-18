using System;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers
{
    public static class PredictionMatrixHelper
    {
        public static void SetImageMatrices(ImageMatrices imageMatrices, NearLosslessOptions nearLosslessOptions)
        {
            var predictor = NearLosslessPredictorSelector.GetPredictor(nearLosslessOptions.PredictorType);

            HandleFirstPixel(imageMatrices, nearLosslessOptions);
            HandleFirstColumn(imageMatrices, nearLosslessOptions, predictor);
            HandleFirstRow(imageMatrices, nearLosslessOptions, predictor);

            for (var row = 1; row < imageMatrices.Width; row++)
            {
                for (var column = 1; column < imageMatrices.Height; column++)
                {
                    var a = imageMatrices.Decoded[row - 1, column];
                    var b = imageMatrices.Decoded[row, column - 1];
                    var c = imageMatrices.Decoded[row - 1, column - 1];

                    var prediction = predictor.PredictValue(a, b, c);

                    HandlePrediction(imageMatrices, nearLosslessOptions, row, column, prediction);
                }
            }
        }

        private static void HandleFirstPixel(ImageMatrices imageMatrices, NearLosslessOptions nearLosslessOptions)
        {
            var halfway = (nearLosslessOptions.PredictionUpperLimit - nearLosslessOptions.PredictionLowerLimit) / 2.0;
            var rounded = (int)Math.Ceiling(halfway);

            HandlePrediction(imageMatrices, nearLosslessOptions, 0, 0, rounded.ToAbsoluteByte());
        }

        private static void HandleFirstColumn(ImageMatrices imageMatrices, NearLosslessOptions nearLosslessOptions, INearLosslessPredictor predictor)
        {
            const byte b = 0;
            const byte c = 0;

            for (var row = 1; row < imageMatrices.Width; row++)
            {
                var a = imageMatrices.Decoded[row - 1, 0];
                var prediction = predictor.PredictValue(a, b, c);

                HandlePrediction(imageMatrices, nearLosslessOptions, row, 0, prediction);
            }
        }

        private static void HandleFirstRow(ImageMatrices imageMatrices, NearLosslessOptions nearLosslessOptions, INearLosslessPredictor predictor)
        {
            const byte a = 0;
            const byte c = 0;

            for (var column = 1; column < imageMatrices.Height; column++)
            {
                var b = imageMatrices.Decoded[0, column - 1];
                var prediction = predictor.PredictValue(a, b, c);

                HandlePrediction(imageMatrices, nearLosslessOptions, 0, column, prediction);
            }
        }

        private static void HandlePrediction(ImageMatrices imageMatrices, NearLosslessOptions nearLosslessOptions, int row, int column, byte prediction)
        {
            var k = nearLosslessOptions.K;

            var error = imageMatrices.Codes[row, column] - prediction;
            var quantizedError = Quantize(error, k);
            var dequantizedError = Dequantize(quantizedError, k);
            var decoded = GetByte(dequantizedError + prediction, nearLosslessOptions.PredictionLowerLimit, nearLosslessOptions.PredictionUpperLimit);

            imageMatrices.Predictions[row, column] = prediction;
            imageMatrices.Errors[row, column] = error;
            imageMatrices.QuantizedErrors[row, column] = quantizedError;
            imageMatrices.DequantizedErrors[row, column] = dequantizedError;
            imageMatrices.Decoded[row, column] = decoded;
        }

        private static int Quantize(int value, int k)
        {
            var result = (value + k) / (2.0 * k + 1);
            var roundedResult = (int)Math.Floor(result);

            return roundedResult;
        }

        private static int Dequantize(int value, int k)
        {
            return value * (2 * k + 1);
        }

        private static byte GetByte(int value, byte lowerLimit, byte upperLimit)
        {
            if (value < lowerLimit)
            {
                return lowerLimit;
            }

            if (value > upperLimit)
            {
                return upperLimit;
            }

            return (byte)value;
        }
    }
}
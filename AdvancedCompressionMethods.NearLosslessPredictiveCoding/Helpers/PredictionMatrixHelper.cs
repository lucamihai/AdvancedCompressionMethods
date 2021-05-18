﻿using System;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers
{
    public static class PredictionMatrixHelper
    {
        public static void SetImageMatrices(ImageMatrices imageMatrices, INearLosslessPredictor predictor)
        {
            HandleFirstPixel(imageMatrices);
            HandleFirstColumn(imageMatrices, predictor);
            HandleFirstRow(imageMatrices, predictor);

            for (var row = 1; row < imageMatrices.Width; row++)
            {
                for (var column = 1; column < imageMatrices.Height; column++)
                {
                    var a = imageMatrices.Decoded[row - 1, column];
                    var b = imageMatrices.Decoded[row, column - 1];
                    var c = imageMatrices.Decoded[row - 1, column - 1];

                    var prediction = predictor.PredictValue(a, b, c);

                    HandlePrediction(imageMatrices, row, column, prediction);
                }
            }
        }

        private static void HandleFirstPixel(ImageMatrices imageMatrices)
        {
            HandlePrediction(imageMatrices, 0, 0, 8);
        }

        private static void HandleFirstColumn(ImageMatrices imageMatrices, INearLosslessPredictor predictor)
        {
            const byte b = 0;
            const byte c = 0;

            for (var row = 1; row < imageMatrices.Width; row++)
            {
                var a = imageMatrices.Decoded[row - 1, 0];
                var prediction = predictor.PredictValue(a, b, c);

                HandlePrediction(imageMatrices, row, 0, prediction);
            }
        }

        private static void HandleFirstRow(ImageMatrices imageMatrices, INearLosslessPredictor predictor)
        {
            const byte a = 0;
            const byte c = 0;

            for (var column = 1; column < imageMatrices.Height; column++)
            {
                var b = imageMatrices.Decoded[0, column - 1];
                var prediction = predictor.PredictValue(a, b, c);

                HandlePrediction(imageMatrices, 0, column, prediction);
            }
        }

        private static void HandlePrediction(ImageMatrices imageMatrices, int row, int column, byte prediction)
        {
            // TODO: Parametrize this
            const int k = 2;

            var error = imageMatrices.Codes[row, column] - prediction;
            var quantizedError = Quantize(error, k);
            var dequantizedError = Dequantize(quantizedError, k);
            var decoded = GetByte(dequantizedError + prediction);

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

        private static byte GetByte(int value)
        {
            // TODO: Extract lower and upper limits

            if (value < 0)
            {
                return 0;
            }

            if (value > 15)
            {
                return 15;
            }

            return (byte)value;
        }
    }
}
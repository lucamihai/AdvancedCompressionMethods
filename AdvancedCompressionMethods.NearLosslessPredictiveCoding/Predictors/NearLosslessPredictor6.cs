﻿using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor6 : INearLosslessPredictor
    {
        public byte PredictValue(byte min, byte max, params byte[] values)
        {
            var a = values[0];
            var b = values[1];
            var c = values[2];

            var result = b + (a - c) / 2;

            return result.ToAbsoluteByte(min, max);
        }
    }
}
﻿using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor5 : INearLosslessPredictor
    {
        public byte PredictValue(byte min, byte max, params byte[] values)
        {
            var a = values[0];
            var b = values[1];
            var c = values[2];

            // TODO: Formula is unclear in PDF. Clarify final form of formula
            var result = a + (b - c) / 2;

            return result.ToAbsoluteByte(min, max);
        }
    }
}
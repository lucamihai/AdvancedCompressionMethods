using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor7 : INearLosslessPredictor
    {
        public byte PredictValue(byte min, byte max, params byte[] values)
        {
            var a = values[0];
            var b = values[1];

            var result = (a + b) / 2;

            return result.ToAbsoluteByte(min, max);
        }
    }
}
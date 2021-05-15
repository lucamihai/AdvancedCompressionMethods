using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor7 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            var a = values[0];
            var b = values[1];

            var result = (a + b) / 2;

            return result.ToAbsoluteByte();
        }
    }
}
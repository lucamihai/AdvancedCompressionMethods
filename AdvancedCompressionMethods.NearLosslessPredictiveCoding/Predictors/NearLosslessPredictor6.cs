using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    public class NearLosslessPredictor6 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            var a = values[0];
            var b = values[1];
            var c = values[2];

            var result = b + (a - c) / 2;

            return result.ToAbsoluteByte();
        }
    }
}
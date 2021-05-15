using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor1 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return values[0];
        }
    }
}
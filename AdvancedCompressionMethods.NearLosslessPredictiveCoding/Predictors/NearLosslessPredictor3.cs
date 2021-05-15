using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor3 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return values[2];
        }
    }
}
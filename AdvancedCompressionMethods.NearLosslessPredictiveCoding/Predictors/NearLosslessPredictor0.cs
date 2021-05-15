using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor0 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return 128;
        }
    }
}
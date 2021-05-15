using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    public class NearLosslessPredictor2 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return values[1];
        }
    }
}
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    internal class NearLosslessPredictor3 : INearLosslessPredictor
    {
        public byte PredictValue(byte min, byte max, params byte[] values)
        {
            return values[2];
        }
    }
}
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    public class NearLosslessPredictor5 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            var a = values[0];
            var b = values[1];
            var c = values[2];

            // TODO: Formula is unclear in PDF. Clarify final form of formula
            var result = a + (b - c) / 2;

            return result.ToAbsoluteByte();
        }
    }
}
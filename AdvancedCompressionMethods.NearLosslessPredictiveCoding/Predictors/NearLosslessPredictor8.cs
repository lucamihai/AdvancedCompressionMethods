using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors
{
    public class NearLosslessPredictor8 : INearLosslessPredictor
    {
        public byte PredictValue(params byte[] values)
        {
            var a = values[0];
            var b = values[1];
            var c = values[2];

            if (c >= Max(a, b))
            {
                return Min(a, b);
            }

            if (c <= Min(a, b))
            {
                return Max(a, b);
            }

            var result = a + b - c;

            return result.ToAbsoluteByte();
        }

        private static byte Min(byte b1, byte b2)
        {
            return b1 < b2
                ? b1
                : b2;
        }

        private static byte Max(byte b1, byte b2)
        {
            return b1 > b2
                ? b1
                : b2;
        }
    }
}
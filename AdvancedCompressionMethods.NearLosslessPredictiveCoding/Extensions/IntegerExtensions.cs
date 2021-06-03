namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions
{
    internal static class IntegerExtensions
    {
        public static byte ToAbsoluteByte(this int number, byte min, byte max)
        {
            // TODO: Extract lower and upper limits

            if (number < min)
            {
                return min;
            }

            if (number > max)
            {
                return max;
            }

            return (byte) number;
        }
    }
}
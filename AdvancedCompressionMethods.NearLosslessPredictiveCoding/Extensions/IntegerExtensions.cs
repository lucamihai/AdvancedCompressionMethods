namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions
{
    internal static class IntegerExtensions
    {
        public static byte ToAbsoluteByte(this int number, byte min, byte max)
        {
            // TODO: Extract lower and upper limits

            if (number < 0)
            {
                return 0;
            }

            if (number > 255)
            {
                return 255;
            }

            return (byte) number;
        }
    }
}
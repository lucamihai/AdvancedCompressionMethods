namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions
{
    internal static class IntegerExtensions
    {
        public static byte ToAbsoluteByte(this int number)
        {
            // TODO: Extract lower and upper limits

            if (number < 0)
            {
                return 0;
            }

            if (number > 15)
            {
                return 15;
            }

            return (byte) number;
        }
    }
}
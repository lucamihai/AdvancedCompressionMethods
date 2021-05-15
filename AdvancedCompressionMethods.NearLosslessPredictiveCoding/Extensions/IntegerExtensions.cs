using System;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Extensions
{
    internal static class IntegerExtensions
    {
        public static byte ToAbsoluteByte(this int number)
        {
            return (byte)Math.Abs(number);
        }
    }
}
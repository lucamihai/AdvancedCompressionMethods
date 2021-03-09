using System.Diagnostics.CodeAnalysis;

namespace AdvancedCompressionMethods.FileOperations.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public const string TestFileNameImage = "testImage.png";
        public const string TestFileNameImageDestination = "testImageWritten.png";
        public const string TestFileName = "testFile.txt";
        public static readonly byte[] TestBytes = new byte[]
        {
            // Binary representation
            11, // 0000 1011
            4,  // 0000 0100
            7   // 0000 0111
        };

        // Binary: 0000 0011
        public const byte ValueFromFirstByteBits012 = 3;

        // Binary: 0001 0000
        public const byte ValueFromFirstByteBits78FollowedBySecondByteBits012 = 16;

        // Binary: 1010
        public const byte ValueTenOnFourBits = 10;

        // Binary: 10
        public const byte ValueTenOnTwoBits = 2;
    }
}
using System;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.ErrorMatrixReaders
{
    public class JpegTableErrorMatrixReader : INearLosslessErrorMatrixReader
    {
        public int[,] ReadErrorMatrix(IFileReader fileReader)
        {
            // TODO: Determine matrix size at runtime
            var errorMatrix = new int[256, 256];

            for (var row = 0; row < 256; row++)
            {
                for (var column = 0; column < 256; column++)
                {
                    var number = GetNextNumber(fileReader);
                    errorMatrix[row, column] = number;
                }
            }

            return errorMatrix;
        }

        private static int GetNextNumber(IFileReader fileReader)
        {
            var bitsToRead = 0;
            while (fileReader.ReadBit())
            {
                bitsToRead++;
            }

            if (bitsToRead == 0)
            {
                return 0;
            }

            var value = fileReader.ReadBits((byte)bitsToRead);
            var maxValueForGivenBits = Math.Pow(2, bitsToRead) - 1;

            if (value < maxValueForGivenBits / 2)
            {
                var cv = (int)(maxValueForGivenBits - value) * (-1);
                return cv;
            }

            return (int)value;
        }
    }
}
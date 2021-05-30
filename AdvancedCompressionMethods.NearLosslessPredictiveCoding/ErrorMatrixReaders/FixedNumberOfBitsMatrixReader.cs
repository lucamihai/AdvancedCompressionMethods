using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.ErrorMatrixReaders
{
    public class FixedNumberOfBitsErrorMatrixReader : INearLosslessErrorMatrixReader
    {
        // TODO: Parametrize this?
        private const byte NumberOfBits = 9;

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
            var isNegativeNumber = fileReader.ReadBit();
            var absoluteNumber = (int)fileReader.ReadBits(NumberOfBits - 1);
            var number = isNegativeNumber
                ? absoluteNumber * (-1)
                : absoluteNumber;

            return number;
        }
    }
}
using System;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.ErrorMatrixWriters
{
    public class FixedNumberOfBitsMatrixWriter : INearLosslessErrorMatrixWriter
    {
        // TODO: Parametrize this?
        private const byte NumberOfBits = 9;

        public void WriteErrorMatrix(int[,] errorMatrix, IFileWriter fileWriter)
        {
            for (var row = 0; row < errorMatrix.GetLength(0); row++)
            {
                for (var column = 0; column < errorMatrix.GetLength(1); column++)
                {
                    var number = errorMatrix[row, column];
                    WriteNumber(number, fileWriter);
                }
            }
        }

        private static void WriteNumber(int number, IFileWriter fileWriter)
        {
            var isNegativeNumber = number < 0;
            var absoluteNumber = (uint)Math.Abs(number);
            fileWriter.WriteBit(isNegativeNumber);
            fileWriter.WriteValueOnBits(absoluteNumber, NumberOfBits - 1);
        }
    }
}
using System;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.ErrorMatrixWriters
{
    public class JpegTableErrorMatrixWriter : INearLosslessErrorMatrixWriter
    {
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
            var requiredBits = NumberOfBitsRequiredForNumber(Math.Abs(number));

            for (var i = 0; i < requiredBits; i++)
            {
                fileWriter.WriteBit(true);
            }

            fileWriter.WriteBit(false);

            if (number == 0)
            {
                return;
            }
            
            if (number < 0)
            {
                var maxValueForGivenBits = Math.Pow(2, requiredBits) - 1;
                var numberToWrite = (uint)(maxValueForGivenBits + number);
                fileWriter.WriteValueOnBits(numberToWrite, (byte)requiredBits);
            }
            else
            {
                fileWriter.WriteValueOnBits((uint)number, (byte)requiredBits);
            }
        }

        private static int NumberOfBitsRequiredForNumber(int number)
        {
            return (int)Math.Log(number, 2) + 1;
        }
    }
}
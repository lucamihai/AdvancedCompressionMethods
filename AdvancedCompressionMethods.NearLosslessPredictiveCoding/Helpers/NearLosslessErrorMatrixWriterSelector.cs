using System;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.ErrorMatrixWriters;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers
{
    public static class NearLosslessErrorMatrixWriterSelector
    {
        public static INearLosslessErrorMatrixWriter GetErrorMatrixWriter(NearLosslessErrorMatrixSaveMode saveMode)
        {
            switch (saveMode)
            {
                case NearLosslessErrorMatrixSaveMode.FixedNumberOfBits:
                {
                    return new FixedNumberOfBitsMatrixWriter();
                }

                case NearLosslessErrorMatrixSaveMode.JpegTable:
                {
                    return new JpegTableErrorMatrixWriter();
                }

                case NearLosslessErrorMatrixSaveMode.ArithmeticCoding:
                {
                    throw new NotImplementedException();
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(saveMode), saveMode, null);
            }
        }
    }
}
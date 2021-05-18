using System;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.ErrorMatrixReaders;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers
{
    public static class NearLosslessErrorMatrixReaderSelector
    {
        public static INearLosslessErrorMatrixReader GetErrorMatrixReader(NearLosslessErrorMatrixSaveMode saveMode)
        {
            switch (saveMode)
            {
                case NearLosslessErrorMatrixSaveMode.FixedNumberOfBits:
                {
                    throw new NotImplementedException();
                }

                case NearLosslessErrorMatrixSaveMode.JpegTable:
                {
                    return new JpegTableErrorMatrixReader();
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
using AdvancedCompressionMethods.FileOperations.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessErrorMatrixWriter
    {
        void WriteErrorMatrix(int[,] errorMatrix, IFileWriter fileWriter);
    }
}
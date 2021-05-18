using AdvancedCompressionMethods.FileOperations.Interfaces;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessErrorMatrixReader
    {
        int[,] ReadErrorMatrix(IFileReader fileReader);
    }
}
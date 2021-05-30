using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessPredictiveDecoder
    {
        ImageMatrices Decode(string sourceFilepath, string destinationFilepath);
    }
}
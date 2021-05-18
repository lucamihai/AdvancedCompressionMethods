using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessPredictiveEncoder
    {
        void Encode(string sourceFilepath, string destinationFilepath, NearLosslessOptions nearLosslessOptions);
    }
}
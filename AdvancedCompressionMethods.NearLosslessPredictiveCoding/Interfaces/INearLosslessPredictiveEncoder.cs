using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessPredictiveEncoder
    {
        void Encode(string sourceFilepath, string destinationFilepath, NearLosslessPredictorType predictorType);
    }
}
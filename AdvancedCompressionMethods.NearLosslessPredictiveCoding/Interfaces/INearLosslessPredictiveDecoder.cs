namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessPredictiveDecoder
    {
        void Decode(string sourceFilepath, string destinationFilepath);
    }
}
namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessPredictor
    {
        byte PredictValue(params byte[] values);
    }
}
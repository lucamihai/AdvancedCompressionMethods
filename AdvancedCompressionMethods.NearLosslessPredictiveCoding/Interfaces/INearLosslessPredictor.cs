namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    public interface INearLosslessPredictor
    {
        byte PredictValue(byte min, byte max, params byte[] values);
    }
}
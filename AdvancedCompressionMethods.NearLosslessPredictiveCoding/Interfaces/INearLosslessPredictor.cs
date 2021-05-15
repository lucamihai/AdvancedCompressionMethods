namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces
{
    internal interface INearLosslessPredictor
    {
        byte PredictValue(params byte[] values);
    }
}
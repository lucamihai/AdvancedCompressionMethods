using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Entities
{
    public class NearLosslessOptions
    {
        public int K { get; set; }
        public NearLosslessPredictorType PredictorType { get; set; }
        public NearLosslessErrorMatrixSaveMode SaveMode { get; set; }
        public byte PredictionLowerLimit { get; set; }
        public byte PredictionUpperLimit { get; set; }
    }
}
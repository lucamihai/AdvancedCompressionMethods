using System;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Predictors;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.Helpers
{
    public static class NearLosslessPredictorSelector
    {
        public static INearLosslessPredictor GetPredictor(NearLosslessPredictorType nearLosslessPredictor)
        {
            switch (nearLosslessPredictor)
            {
                case NearLosslessPredictorType.Predictor0:
                {
                    return new NearLosslessPredictor0();
                }
                case NearLosslessPredictorType.Predictor1:
                {
                    return new NearLosslessPredictor1();
                }
                case NearLosslessPredictorType.Predictor2:
                {
                    return new NearLosslessPredictor2();
                }
                case NearLosslessPredictorType.Predictor3:
                {
                    return new NearLosslessPredictor3();
                }
                case NearLosslessPredictorType.Predictor4:
                {
                    return new NearLosslessPredictor4();
                }
                case NearLosslessPredictorType.Predictor5:
                {
                    return new NearLosslessPredictor5();
                }
                case NearLosslessPredictorType.Predictor6:
                {
                    return new NearLosslessPredictor6();
                }
                case NearLosslessPredictorType.Predictor7:
                {
                    return new NearLosslessPredictor7();
                }
                case NearLosslessPredictorType.Predictor8:
                {
                    return new NearLosslessPredictor8();
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(nearLosslessPredictor), nearLosslessPredictor, null);
            }
        }
    }
}
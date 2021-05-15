using System;
using System.Diagnostics.CodeAnalysis;
using AdvancedCompressionMethods.DI;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Enums;
using AdvancedCompressionMethods.NearLosslessPredictiveCoding.Interfaces;
using AdvancedCompressionMethods.Tests.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.NearLosslessPredictiveCoding.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NearLosslessPredictiveEncoderPlusDecoderIntegrationTests
    {
        private INearLosslessPredictiveEncoder encoder;
        private INearLosslessPredictiveDecoder decoder;
        private string filepathSource;
        private string filepathEncodedFile;
        private string filepathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            var serviceProvider = DependencyResolver.GetServices().BuildServiceProvider();
            encoder = serviceProvider.GetRequiredService<INearLosslessPredictiveEncoder>();
            decoder = serviceProvider.GetRequiredService<INearLosslessPredictiveDecoder>();

            filepathSource = $"{Environment.CurrentDirectory}\\temp.bmp";
            filepathEncodedFile = $"{Environment.CurrentDirectory}\\temp.bmp.pre";
            filepathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.pre.bmp";
        }

        [TestMethod]
        [DataRow(NearLosslessPredictorType.Predictor0, DisplayName = "Predictor0")]
        [DataRow(NearLosslessPredictorType.Predictor1, DisplayName = "Predictor1")]
        [DataRow(NearLosslessPredictorType.Predictor2, DisplayName = "Predictor2")]
        [DataRow(NearLosslessPredictorType.Predictor3, DisplayName = "Predictor3")]
        [DataRow(NearLosslessPredictorType.Predictor4, DisplayName = "Predictor4")]
        [DataRow(NearLosslessPredictorType.Predictor5, DisplayName = "Predictor5")]
        [DataRow(NearLosslessPredictorType.Predictor6, DisplayName = "Predictor6")]
        [DataRow(NearLosslessPredictorType.Predictor7, DisplayName = "Predictor7")]
        [DataRow(NearLosslessPredictorType.Predictor8, DisplayName = "Predictor8")]
        public void TestThatFileIsEncodedThenDecodedCorrectly1(NearLosslessPredictorType predictorType)
        {
            var filepathImage = $"{Environment.CurrentDirectory}\\Images\\Lenna256an.bmp";
            TestMethods.CopyFileAndReplaceIfAlreadyExists(filepathImage, filepathSource);

            encoder.Encode(filepathSource, filepathEncodedFile, predictorType);
            decoder.Decode(filepathEncodedFile, filepathDecodedFile);

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filepathSource, filepathDecodedFile));
        }

        [TestMethod]
        [DataRow(NearLosslessPredictorType.Predictor0, DisplayName = "Predictor0")]
        [DataRow(NearLosslessPredictorType.Predictor1, DisplayName = "Predictor1")]
        [DataRow(NearLosslessPredictorType.Predictor2, DisplayName = "Predictor2")]
        [DataRow(NearLosslessPredictorType.Predictor3, DisplayName = "Predictor3")]
        [DataRow(NearLosslessPredictorType.Predictor4, DisplayName = "Predictor4")]
        [DataRow(NearLosslessPredictorType.Predictor5, DisplayName = "Predictor5")]
        [DataRow(NearLosslessPredictorType.Predictor6, DisplayName = "Predictor6")]
        [DataRow(NearLosslessPredictorType.Predictor7, DisplayName = "Predictor7")]
        [DataRow(NearLosslessPredictorType.Predictor8, DisplayName = "Predictor8")]
        public void TestThatFileIsEncodedThenDecodedCorrectly2(NearLosslessPredictorType predictorType)
        {
            var filepathImage = $"{Environment.CurrentDirectory}\\Images\\Peppers256an.bmp";
            TestMethods.CopyFileAndReplaceIfAlreadyExists(filepathImage, filepathSource);

            encoder.Encode(filepathSource, filepathEncodedFile, predictorType);
            decoder.Decode(filepathEncodedFile, filepathDecodedFile);

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filepathSource, filepathDecodedFile));
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filepathSource);
            TestMethods.DeleteFileIfExists(filepathEncodedFile);
            TestMethods.DeleteFileIfExists(filepathDecodedFile);
        }
    }
}

using System;
using System.Diagnostics.CodeAnalysis;
using AdvancedCompressionMethods.ArithmeticCoding.Interfaces;
using AdvancedCompressionMethods.DI;
using AdvancedCompressionMethods.Tests.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.ArithmeticCoding.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ArithmeticEncoderPlusDecoderIntegrationTests
    {
        private IArithmeticEncoder arithmeticEncoder;
        private IArithmeticDecoder arithmeticDecoder;
        private string filepathSource;
        private string filepathEncodedFile;
        private string filepathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            var serviceProvider = DependencyResolver.GetServices().BuildServiceProvider();
            arithmeticEncoder = serviceProvider.GetRequiredService<IArithmeticEncoder>();
            arithmeticDecoder = serviceProvider.GetRequiredService<IArithmeticDecoder>();

            filepathSource = $"{Environment.CurrentDirectory}\\temp.txt";
            filepathEncodedFile = $"{Environment.CurrentDirectory}\\temp.txt.ac";
            filepathDecodedFile = $"{Environment.CurrentDirectory}\\temp.txt.ac.txt";
        }

        [TestMethod]
        [DataRow(TestFileContents.FileTextContents1, DisplayName = "FileTextContents1")]
        [DataRow(TestFileContents.FileTextContents2, DisplayName = "FileTextContents2")]
        [DataRow(TestFileContents.FileTextContents3, DisplayName = "FileTextContents3")]
        public void TestThatFileIsEncodedThenDecodedCorrectly(string fileTextContents)
        {
            TestMethods.CreateFileWithTextContents(filepathSource, fileTextContents);

            arithmeticEncoder.EncodeFile(filepathSource, filepathEncodedFile);
            arithmeticDecoder.DecodeFile(filepathEncodedFile, filepathDecodedFile);

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

using System;
using System.Diagnostics.CodeAnalysis;
using AdvancedCompressionMethods.DI;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.Tests.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderAndFileWriterIntegrationTests
    {
        private IFileReader fileReader;
        private IFileWriter fileWriter;
        private string filepathSource;
        private string filepathDestination;

        [TestInitialize]
        public void Setup()
        {
            var serviceProvider = DependencyResolver.GetServices().BuildServiceProvider();
            fileReader = serviceProvider.GetRequiredService<IFileReader>();
            fileWriter = serviceProvider.GetRequiredService<IFileWriter>();

            filepathSource = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImage}";
            filepathDestination = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImageDestination}";
        }

        [TestMethod]
        [DataRow(TestFileContents.FileTextContents1, DisplayName = "FileTextContents1")]
        [DataRow(TestFileContents.FileTextContents2, DisplayName = "FileTextContents2")]
        [DataRow(TestFileContents.FileTextContents3, DisplayName = "FileTextContents3")]
        public void TestThatFileIsCopiedCorrectlyForNumberOfBitsBetween1And8(string fileTextContents)
        {
            TestMethods.CreateFileWithTextContents(filepathSource, fileTextContents);
            var random = new Random();

            fileReader.Open(filepathSource);
            fileWriter.Open(filepathDestination);

            while (!fileReader.ReachedEndOfFile)
            {
                var numberOfBits = fileReader.BitsLeft < 8
                    ? (byte)fileReader.BitsLeft
                    : (byte)random.Next(1, 8);

                var readStuff = fileReader.ReadBits(numberOfBits);
                fileWriter.WriteValueOnBits(readStuff, numberOfBits);
            }
            
            fileReader.Close();
            fileWriter.Close();

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filepathSource, filepathDestination));
        }

        [TestMethod]
        [DataRow(TestFileContents.FileTextContents1, DisplayName = "FileTextContents1")]
        [DataRow(TestFileContents.FileTextContents2, DisplayName = "FileTextContents2")]
        [DataRow(TestFileContents.FileTextContents3, DisplayName = "FileTextContents3")]
        public void TestThatFileIsCopiedCorrectlyForNumberOfBitsBetween8And32(string fileTextContents)
        {
            TestMethods.CreateFileWithTextContents(filepathSource, fileTextContents);
            var random = new Random();

            fileReader.Open(filepathSource);
            fileWriter.Open(filepathDestination);

            while (!fileReader.ReachedEndOfFile)
            {
                var numberOfBits = fileReader.BitsLeft < 32
                    ? (byte)fileReader.BitsLeft
                    : (byte)random.Next(8, 32);

                var readStuff = fileReader.ReadBits(numberOfBits);
                fileWriter.WriteValueOnBits(readStuff, numberOfBits);
            }
            
            fileReader.Close();
            fileWriter.Close();
            
            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filepathSource, filepathDestination));
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filepathSource);
            TestMethods.DeleteFileIfExists(filepathDestination);
        }
    }
}
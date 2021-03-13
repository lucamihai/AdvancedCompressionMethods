using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AdvancedCompressionMethods.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    //[Ignore]
    public class FileReaderAndFileWriterIntegrationTests
    {
        private FileReader fileReader;
        private FileWriter fileWriter;
        private string filePathSource;
        private string filePathDestination;
        private long originalFileSizeInBytes;

        [TestInitialize]
        public void Setup()
        {
            fileReader = new FileReader(new Buffer());
            fileWriter = new FileWriter(new Buffer());

            filePathSource = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImage}";
            filePathDestination = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImageDestination}";

            TestMethods.CopyFileAndReplaceIfAlreadyExists($"{Environment.CurrentDirectory}\\Resources\\{Constants.TestFileNameImage}", filePathSource);

            originalFileSizeInBytes = new FileInfo(filePathSource).Length;

            fileReader.Open(filePathSource);
            fileWriter.Open(filePathDestination);
        }

        [TestMethod]
        public void TestThatFileIsCopiedCorrectlyForNumberOfBitsBetween1And8()
        {
            var random = new Random();
            var stopWatch = Stopwatch.StartNew();

            while (!fileReader.ReachedEndOfFile)
            {
                var numberOfBits = fileReader.BitsLeft < 8
                    ? (byte)fileReader.BitsLeft
                    : (byte)random.Next(1, 8);

                var readStuff = fileReader.ReadBits(numberOfBits);
                fileWriter.WriteValueOnBits(readStuff, numberOfBits);
            }
            
            stopWatch.Stop();
            fileReader.Close();
            fileWriter.Close();

            Console.WriteLine($"File copying in '{TestMethods.GetCurrentMethodName()}' took {stopWatch.ElapsedMilliseconds} ms for {originalFileSizeInBytes} bytes");

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDestination));
        }

        [TestMethod]
        public void TestThatFileIsCopiedCorrectlyForNumberOfBitsBetween8And32()
        {
            var random = new Random();
            var stopWatch = Stopwatch.StartNew();

            while (!fileReader.ReachedEndOfFile)
            {
                var numberOfBits = fileReader.BitsLeft < 32
                    ? (byte)fileReader.BitsLeft
                    : (byte)random.Next(8, 32);

                var readStuff = fileReader.ReadBits(numberOfBits);

                fileWriter.WriteValueOnBits(readStuff, numberOfBits);
            }
            
            stopWatch.Stop();
            fileReader.Close();
            fileWriter.Close();

            Console.WriteLine($"File copying in '{TestMethods.GetCurrentMethodName()}' took {stopWatch.ElapsedMilliseconds} ms for {originalFileSizeInBytes} bytes");

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDestination));
        }

        [TestCleanup]
        public void Cleanup()
        {
            fileReader.Close();
            fileWriter.Close();

            TestMethods.DeleteFileIfExists(filePathSource);
            TestMethods.DeleteFileIfExists(filePathDestination);
        }
    }
}
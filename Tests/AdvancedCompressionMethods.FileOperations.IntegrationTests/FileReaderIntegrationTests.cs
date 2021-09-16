using System;
using System.Diagnostics.CodeAnalysis;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.FileOperations.Validators;
using AdvancedCompressionMethods.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderIntegrationTests
    {
        private FileReader fileReader;
        private string filePath;
        private IBuffer buffer;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            buffer = new Buffer();

            TestMethods.CreateFileWithGivenBytes(filePath, Constants.TestBytes);

            fileReader = new FileReader(buffer, new FilepathValidator());
            fileReader.Open(filePath);
        }

        [TestMethod]
        public void TestThatBufferIsInitializedWithFirstByteFromFile()
        {
            Assert.AreEqual(Constants.TestBytes[0], buffer.Value);
        }

        [TestMethod]
        public void TestThatBufferIsInitializedWithCurrentBitSetToZero()
        {
            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatReadBitReturnsExpectedValue1()
        {
            var bitValue = fileReader.ReadBit();

            Assert.IsTrue(bitValue);
        }

        [TestMethod]
        public void TestThatReadBitReturnsExpectedValue2()
        {
            buffer.CurrentBit = 2;

            var bitValue = fileReader.ReadBit();

            Assert.IsFalse(bitValue);
        }

        [TestMethod]
        public void TestThatReadBitIncreasesBufferCurrentBitByOne()
        {
            var bufferCurrentBitInitialValue = buffer.CurrentBit;

            fileReader.ReadBit();

            Assert.AreEqual(bufferCurrentBitInitialValue + 1, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatReadBitResetsBufferCurrentBitIfCurrentBitIsEqualTo7()
        {
            buffer.CurrentBit = 7;

            fileReader.ReadBit();

            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatReadBitChangesBufferValueToNextByteFromFileIfCurrentBitIsEqualTo7()
        {
            buffer.CurrentBit = 7;

            fileReader.ReadBit();

            Assert.AreEqual(Constants.TestBytes[1], buffer.Value);
        }

        [TestMethod]
        public void TestThatReadBitsReturnsExpectedValue()
        {
            var value = fileReader.ReadBits(3);

            Assert.AreEqual(Constants.ValueFromFirstByteBits012, value);
        }

        [TestMethod]
        public void TestThatReadBitsReturnsExpectedValueForOverflow()
        {
            buffer.CurrentBit = 6;

            var value = fileReader.ReadBits(5);

            Assert.AreEqual(Constants.ValueFromFirstByteBits78FollowedBySecondByteBits012, value);
        }

        [TestMethod]
        public void TestThatReadBitsIncreasesBufferCurrentBitByNumberOfBitsFromParameter()
        {
            var bufferCurrentBitInitialValue = buffer.CurrentBit;
            const byte numberOfBitsToRead = 4;

            fileReader.ReadBits(numberOfBitsToRead);

            var expectedCurrentBit = bufferCurrentBitInitialValue + numberOfBitsToRead;
            Assert.AreEqual(expectedCurrentBit, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatReadBitsSetsCurrentBitValueAsExpectedForOverflow()
        {
            const byte numberOfBitsToRead = 5;

            fileReader.ReadBits(numberOfBitsToRead);
            fileReader.ReadBits(numberOfBitsToRead);

            Assert.AreEqual(2, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatReadBitsSetsValueAsExpectedForOverflow()
        {
            const byte numberOfBitsToRead = 5;

            fileReader.ReadBits(numberOfBitsToRead);
            fileReader.ReadBits(numberOfBitsToRead);

            Assert.AreEqual(Constants.TestBytes[1], buffer.Value);
        }

        [TestCleanup]
        public void Cleanup()
        {
            fileReader?.Dispose();

            TestMethods.DeleteFileIfExists(filePath);
        }
    }
}
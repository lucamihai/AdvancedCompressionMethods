using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileWriterIntegrationTests
    {
        private FileWriter fileWriter;
        private string filePath;
        private IBuffer buffer;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            buffer = new Buffer();

            fileWriter = new FileWriter(buffer);
            fileWriter.Open(filePath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            fileWriter?.Dispose();

            TestMethods.DeleteFileIfExists(filePath);
        }

        [TestMethod]
        public void TestThatBufferIsInitializedWithValueSetToZero()
        {
            Assert.AreEqual(0, buffer.Value);
        }

        [TestMethod]
        public void TestThatBufferIsInitializedWithCurrentBitSetToZero()
        {
            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatWriteBitAddsExpectedValueToBuffer1()
        {
            fileWriter.WriteBit(true);

            Assert.AreEqual(1, buffer.Value);
        }

        [TestMethod]
        public void TestThatWriteBitAddsExpectedValueToBuffer2()
        {
            fileWriter.WriteBit(false);

            Assert.AreEqual(0, buffer.Value);
        }

        [TestMethod]
        public void TestThatWriteBitAddsExpectedValueToBuffer3()
        {
            buffer.Value = 3;
            buffer.CurrentBit = 2;

            fileWriter.WriteBit(true);

            Assert.AreEqual(7, buffer.Value);
        }

        [TestMethod]
        public void TestThatWriteBitAddsExpectedValueToBuffer4()
        {
            buffer.Value = 3;
            buffer.CurrentBit = 2;

            fileWriter.WriteBit(false);

            Assert.AreEqual(3, buffer.Value);
        }

        [TestMethod]
        public void TestThatWriteBitDoesNotWriteByteToFileIfBufferCurrentBitIsLessThanSeven()
        {
            fileWriter.WriteBit(true);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(0, fileBytes.Length);
        }

        [TestMethod]
        public void TestThatWriteBitWritesByteToFileIfBufferCurrentBitIsSeven()
        {
            buffer.CurrentBit = 7;

            fileWriter.WriteBit(true);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(1, fileBytes.Length);
            const byte expectedWrittenByteValue = 128;
            Assert.AreEqual(expectedWrittenByteValue, fileBytes[0]);
        }

        [TestMethod]
        public void TestThatWriteBitIncreasesBufferCurrentBitByOne()
        {
            var bufferInitialCurrentBit = buffer.CurrentBit;

            fileWriter.WriteBit(true);

            Assert.AreEqual(bufferInitialCurrentBit + 1, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatWriteBitResetsBufferCurrentBitIfCurrentBitIsSeven()
        {
            buffer.CurrentBit = 7;

            fileWriter.WriteBit(true);

            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void TestThatWriteValueOnBitsAddsExpectedValueToBuffer1()
        {
            fileWriter.WriteValueOnBits(10, 4);

            Assert.AreEqual(Constants.ValueTenOnFourBits, buffer.Value);
        }

        [TestMethod]
        public void TestThatWriteValueOnBitsAddsExpectedValueToBuffer2()
        {
            fileWriter.WriteValueOnBits(10, 2);

            Assert.AreEqual(Constants.ValueTenOnTwoBits, buffer.Value);
        }

        [TestMethod]
        public void TestThatWriteValueOnBitsAddsExpectedValueToBuffer4()
        {
            buffer.CurrentBit = 1;

            fileWriter.WriteValueOnBits(10, 2);

            Assert.AreEqual(Constants.ValueTenOnTwoBits << 1, buffer.Value);
        }

        [TestMethod]
        public void TestThatWriteValueOnBitsDoesNotWriteByteToFileIfDoesNotCauseOverflow()
        {
            fileWriter.WriteValueOnBits(10, 4);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(0, fileBytes.Length);
        }

        [TestMethod]
        public void TestThatWriteValueOnBitsWritesByteToFileIfCausesOverflow()
        {
            buffer.CurrentBit = 5;

            fileWriter.WriteValueOnBits(10, 4);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(1, fileBytes.Length);
            const byte expectedWrittenByteValue = 64;
            Assert.AreEqual(expectedWrittenByteValue, fileBytes[0]);
        }
    }
}
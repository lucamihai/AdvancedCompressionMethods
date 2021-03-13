using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.FileOperations.Validators;

namespace AdvancedCompressionMethods.FileOperations
{
    public class FileWriter : IFileWriter, IDisposable
    {
        private const uint EightBitMask = byte.MaxValue;

        private static readonly FilepathValidator FilepathValidator = new FilepathValidator();

        private readonly IBuffer buffer;
        private FileStream fileStream;

        public string FilePath { get; private set; }
        

        public FileWriter(IBuffer buffer)
        {
            this.buffer = buffer;
            this.buffer.OnCurrentBitReset += OnCurrentBitReset;
        }

        public void Open(string filepath)
        {
            FilepathValidator.ValidateAndThrow(filepath, checkIfExists: false);

            FilePath = filepath;
            fileStream = new FileStream(filepath, FileMode.OpenOrCreate);
        }

        public void Close()
        {
            fileStream?.Close();
        }

        public void WriteBit(bool bitValue)
        {
            var valueToWrite = bitValue ? (byte)1 : (byte)0;
            buffer.AddValueStartingFromCurrentBit(valueToWrite, 1);
        }

        public void WriteValueOnBits(uint value, byte numberOfBits)
        {
            if (numberOfBits == 0)
            {
                throw new ArgumentException();
            }

            while (numberOfBits > 0)
            {
                var numberOfBitsToWrite = numberOfBits > 8
                    ? (byte)8
                    : numberOfBits;

                var byteToWrite = numberOfBitsToWrite == 8
                    ? (byte)(value & EightBitMask)
                    : (byte)value;

                buffer.AddValueStartingFromCurrentBit(byteToWrite, numberOfBitsToWrite);

                value >>= numberOfBitsToWrite;
                numberOfBits -= numberOfBitsToWrite;
            }
        }

        public void Flush()
        {
            buffer.Flush();
        }

        [ExcludeFromCodeCoverage]
        private void OnCurrentBitReset(byte valueFromBuffer)
        {
            fileStream.WriteByte(buffer.Value);
            fileStream.Flush();

            buffer.Value = 0;
        }

        #region IDisposable stuff

        [ExcludeFromCodeCoverage]
        ~FileWriter()
        {
            Dispose(false);
        }

        [ExcludeFromCodeCoverage]
        private void ReleaseUnmanagedResources()
        {
            fileStream.Close();
            fileStream.Dispose();
        }

        [ExcludeFromCodeCoverage]
        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                fileStream?.Dispose();
            }
        }

        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
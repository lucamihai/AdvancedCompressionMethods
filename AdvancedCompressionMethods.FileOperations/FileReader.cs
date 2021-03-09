using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.FileOperations.Validators;

namespace AdvancedCompressionMethods.FileOperations
{
    public class FileReader : IFileReader, IDisposable
    {
        private static readonly FilepathValidator FilepathValidator = new FilepathValidator();
        private static readonly BufferValidator BufferValidator = new BufferValidator();

        private FileStream fileStream;

        public bool ReachedEndOfFile { get; private set; }
        public long BitsLeft { get; private set; }

        public string FilePath { get; }
        public IBuffer Buffer { get; private set; }

        public FileReader(string filePath, IBuffer buffer)
        {
            FilepathValidator.ValidateAndThrow(filePath);
            BufferValidator.ValidateAndThrow(buffer);

            FilePath = filePath;
            Buffer = buffer;

            fileStream = new FileStream(filePath, FileMode.Open);
            BitsLeft = fileStream.Length * 8;

            Buffer.OnCurrentBitReset += OnCurrentBitReset;
            Buffer.Value = (byte)fileStream.ReadByte();
        }

        public void Open()
        {
            fileStream = new FileStream(FilePath, FileMode.Open);
            Reset();
        }

        public void Close()
        {
            fileStream.Dispose();
        }

        public void Reset()
        {
            fileStream.Position = 0;
            BitsLeft = fileStream.Length * 8;
            ReachedEndOfFile = false;

            Buffer = new Buffer();
            Buffer.OnCurrentBitReset += OnCurrentBitReset;
            Buffer.Value = (byte)fileStream.ReadByte();
        }

        public bool ReadBit()
        {
            BitsLeft -= 1;
            return Buffer.GetValueStartingFromCurrentBit(1) == 1;
        }

        public uint ReadBits(byte numberOfBits)
        {
            if (numberOfBits == 0)
            {
                throw new ArgumentException();
            }

            BitsLeft -= numberOfBits;

            if (numberOfBits <= 8)
            {
                return Buffer.GetValueStartingFromCurrentBit(numberOfBits);
            }

            var numberOfBitsRead = 0;
            uint valueToReturn = 0;

            while (numberOfBits > 0)
            {
                var numberOfBitsToRead = numberOfBits > 8
                    ? (byte)8
                    : numberOfBits;

                valueToReturn += (uint)Buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead) << numberOfBitsRead;
                numberOfBits -= numberOfBitsToRead;
                numberOfBitsRead += numberOfBitsToRead;
            }

            return valueToReturn;
        }

        [ExcludeFromCodeCoverage]
        private void OnCurrentBitReset(byte valueFromBuffer)
        {
            if (ReachedEndOfFile)
            {
                return;
            }

            if (fileStream.Position == fileStream.Length)
            {
                ReachedEndOfFile = true;
                Buffer.AddValueStartingFromCurrentBit(127, 7);
                return;
            }

            Buffer.Value = (byte)fileStream.ReadByte();
        }

        #region IDisbosable stuff

        [ExcludeFromCodeCoverage]
        ~FileReader()
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
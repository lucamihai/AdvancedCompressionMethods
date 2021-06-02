using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.FileOperations.Interfaces.Validators;

namespace AdvancedCompressionMethods.FileOperations
{
    public class FileReader : IFileReader, IDisposable
    {
        private IBuffer buffer;
        private readonly IFilepathValidator filepathValidator;

        private FileStream fileStream;

        public string FilePath { get; private set; }
        public bool ReachedEndOfFile { get; private set; }
        public long BitsLeft { get; private set; }

        public FileReader(IBuffer buffer, IFilepathValidator filepathValidator)
        {
            this.buffer = buffer;
            this.filepathValidator = filepathValidator;
        }

        public void Open(string filepath)
        {
            filepathValidator.ValidateAndThrow(filepath, checkIfExists: true);

            Close();

            FilePath = filepath;
            fileStream = new FileStream(FilePath, FileMode.Open);
            Reset();
        }

        public void Close()
        {
            fileStream?.Close();
        }

        public void Reset()
        {
            //buffer.OnCurrentBitReset = null;
            //buffer.Reset();
            // TODO: Investigate reinitializing alternative
            buffer = new Buffer();
            buffer.OnCurrentBitReset += OnCurrentBitReset;

            fileStream.Position = 0;
            BitsLeft = fileStream.Length * 8;
            ReachedEndOfFile = false;
            
            buffer.Value = (byte)fileStream.ReadByte();
        }

        public bool ReadBit()
        {
            BitsLeft -= 1;

            return buffer.GetValueStartingFromCurrentBit(1) == 1;
        }

        public uint ReadBits(byte numberOfBits)
        {
            BitsLeft -= numberOfBits;

            if (numberOfBits <= 8)
            {
                return buffer.GetValueStartingFromCurrentBit(numberOfBits);
            }

            var numberOfBitsRead = 0;
            uint valueToReturn = 0;

            while (numberOfBits > 0)
            {
                var numberOfBitsToRead = numberOfBits > 8
                    ? (byte)8
                    : numberOfBits;

                valueToReturn += (uint)buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead) << numberOfBitsRead;
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
                buffer.AddValueStartingFromCurrentBit(127, 7);
                return;
            }

            buffer.Value = (byte)fileStream.ReadByte();
        }

        #region IDisposable stuff

        [ExcludeFromCodeCoverage]
        ~FileReader()
        {
            Dispose(false);
        }

        [ExcludeFromCodeCoverage]
        private void ReleaseUnmanagedResources()
        {
            fileStream?.Close();
            fileStream?.Dispose();
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
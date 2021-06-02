using System.Collections;
using AdvancedCompressionMethods.FileOperations.Interfaces;

namespace AdvancedCompressionMethods.FileOperations
{
    public class Buffer : IBuffer
    {
        private readonly BitArray bitArray;
        private static readonly byte[] ByteValues = new byte[] {1, 2, 4, 8, 16, 32, 64, 128};

        public byte Value
        {
            get => GetByteFromBitArray(bitArray);
            set
            {
                for (var i = 0; i < 8; i++)
                {
                    bitArray[i] = (value & ByteValues[i]) == ByteValues[i];
                }
            }
        }

        private byte previousCurrentBit;
        private byte currentBit;

        public byte CurrentBit
        {
            get => currentBit;
            set
            {
                previousCurrentBit = currentBit;
                currentBit = (byte)(value % 8);

                if (currentBit <= previousCurrentBit)
                {
                    OnCurrentBitReset(Value);
                }
            }
        }

        public delegate void CurrentBitReset(byte valueFromBuffer);
        public CurrentBitReset OnCurrentBitReset { get; set; }

        public Buffer()
        {
            bitArray = new BitArray(8);
            bitArray.SetAll(false);
        }

        public void AddValueStartingFromCurrentBit(byte value, byte numberOfBitsToWrite)
        {
            for (var i = 0; i < numberOfBitsToWrite; i++)
            {
                bitArray[CurrentBit] = (value & ByteValues[i]) == ByteValues[i];
                CurrentBit++;
            }
        }

        public byte GetValueStartingFromCurrentBit(byte numberOfBitsToRead)
        {
            byte value = 0;

            for (var i = 0; i < numberOfBitsToRead; i++)
            {
                value += bitArray[CurrentBit]
                    ? ByteValues[i]
                    : (byte)0;

                CurrentBit++;
            }

            return value;
        }

        public void Flush()
        {
            AddValueStartingFromCurrentBit(127, 7);
        }

        public void Reset()
        {
            bitArray.SetAll(false);
        }

        private static byte GetByteFromBitArray(BitArray bitArray)
        {
            byte value = 0;

            for (var i = 0; i < 8; i++)
            {
                value += bitArray[i]
                    ? ByteValues[i]
                    : (byte)0;
            }

            return value;
        }
    }
}
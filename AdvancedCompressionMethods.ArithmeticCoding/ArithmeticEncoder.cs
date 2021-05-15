using System.Collections.Generic;
using System.Linq;
using AdvancedCompressionMethods.ArithmeticCoding.Entities;
using AdvancedCompressionMethods.ArithmeticCoding.Interfaces;
using AdvancedCompressionMethods.FileOperations.Interfaces;

namespace AdvancedCompressionMethods.ArithmeticCoding
{
    public class ArithmeticEncoder : IArithmeticEncoder
    {
        private readonly IFileReader fileReader;
        private readonly IFileWriter fileWriter;

        private SortedDictionary<char, ArithmeticCodingSymbol> symbolDictionary;
        private uint Low = uint.MinValue;
        private uint High = uint.MaxValue;
        private ulong Range = 1;

        public ArithmeticEncoder(IFileReader fileReader, IFileWriter fileWriter)
        {
            this.fileReader = fileReader;
            this.fileWriter = fileWriter;
        }

        public void EncodeFile(string sourceFilepath, string destinationFilepath)
        {
            fileReader.Open(sourceFilepath);
            var sourceFileBytes = GetAllBytesFromSourceFile();
            fileReader.Close();

            InitializeSymbolDictionaryFromBytes(sourceFileBytes);


            fileWriter.Open(destinationFilepath);
            fileWriter.Close();

            throw new System.NotImplementedException();
        }

        private List<byte> GetAllBytesFromSourceFile()
        {
            var bytes = new List<byte>();

            while (!fileReader.ReachedEndOfFile)
            {
                var value = fileReader.ReadBits(8);
                bytes.Add((byte)value);
            }

            return bytes;
        }

        private void InitializeSymbolDictionaryFromBytes(List<byte> bytes)
        {
            symbolDictionary = new SortedDictionary<char, ArithmeticCodingSymbol>();

            foreach (var byteValue in bytes)
            {
                var character = (char)byteValue;

                if (symbolDictionary.TryGetValue(character, out var symbol))
                {
                    symbol.Count++;
                }
                else
                {
                    var newSymbol = new ArithmeticCodingSymbol {Value = character};
                    symbolDictionary.Add(character, newSymbol);
                }
            }

            for (var i = 1; i < symbolDictionary.Count; i++)
            {
                var symbol = symbolDictionary.ElementAt(i).Value;
                var previousSymbol = symbolDictionary.ElementAt(i - 1).Value;

                symbol.Sum = previousSymbol.Sum + symbol.Count;
            }
        }
    }
}
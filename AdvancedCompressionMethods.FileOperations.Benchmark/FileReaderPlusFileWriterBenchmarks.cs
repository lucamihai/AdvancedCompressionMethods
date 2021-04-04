using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AdvancedCompressionMethods.DI;
using AdvancedCompressionMethods.FileOperations.Interfaces;
using AdvancedCompressionMethods.Tests.Common;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCompressionMethods.FileOperations.Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    [ExcludeFromCodeCoverage]
    public class FileReaderPlusFileWriterBenchmarks
    {
        private readonly IFileReader fileReader;
        private readonly IFileWriter fileWriter;
        private readonly string filepathSource;
        private readonly string filepathDestination;

        public FileReaderPlusFileWriterBenchmarks()
        {
            var serviceProvider = DependencyResolver.GetServices().BuildServiceProvider();
            fileReader = serviceProvider.GetRequiredService<IFileReader>();
            fileWriter = serviceProvider.GetRequiredService<IFileWriter>();

            filepathSource = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImage}";
            filepathDestination = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImageDestination}";
            
            TestMethods.CopyFileAndReplaceIfAlreadyExists($"{Environment.CurrentDirectory}\\Resources\\{Constants.TestFileNameImage}", filepathSource);
        }

        [Benchmark(Baseline = true)]
        public void TestForStandardCopy()
        {
            File.Copy(filepathSource, filepathDestination, true);
        }

        [Benchmark]
        public void TestFor2NumberOfBits()
        {
            RunForThisNumberOfBits(2);
        }

        [Benchmark]
        public void TestFor4NumberOfBits()
        {
            RunForThisNumberOfBits(4);
        }

        [Benchmark]
        public void TestFor8NumberOfBits()
        {
            RunForThisNumberOfBits(8);
        }

        [Benchmark]
        public void TestFor15NumberOfBits()
        {
            RunForThisNumberOfBits(15);
        }

        [Benchmark]
        public void TestFor30NumberOfBits()
        {
            RunForThisNumberOfBits(30);
        }
        
        private void RunForThisNumberOfBits(byte numberOfBits)
        {
            fileReader.Open(filepathSource);
            fileWriter.Open(filepathDestination);

            while (!fileReader.ReachedEndOfFile)
            {
                var numberOfBitsForCurrentIteration = fileReader.BitsLeft < numberOfBits
                    ? (byte)fileReader.BitsLeft
                    : numberOfBits;

                var readStuff = fileReader.ReadBits(numberOfBitsForCurrentIteration);
                fileWriter.WriteValueOnBits(readStuff, numberOfBitsForCurrentIteration);
            }

            fileReader.Close();
            fileWriter.Close();
        }
    }
}
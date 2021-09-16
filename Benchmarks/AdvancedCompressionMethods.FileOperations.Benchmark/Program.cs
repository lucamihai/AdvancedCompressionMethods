using System;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Running;

namespace AdvancedCompressionMethods.FileOperations.Benchmark
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<FileReaderPlusFileWriterBenchmarks>();
            Console.Read();
        }
    }
}

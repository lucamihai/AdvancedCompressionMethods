using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AdvancedCompressionMethods.WaveletCoding.Entities;
using AdvancedCompressionMethods.WaveletCoding.Helpers;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCompressionMethods.WaveletCoding.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WaveletAnalyzerUnitTests
    {
        private WaveletAnalyzer waveletAnalyzer;
        private List<byte> values;
        private WaveletAnalysisCollection expectedResult;
        private CompareLogic compareLogic;

        [TestInitialize]
        public void Setup()
        {
            waveletAnalyzer = new WaveletAnalyzer();

            compareLogic = new CompareLogic();
        }

        [TestMethod]
        public void TestThatGetAnalysisReturnsExpectedResult1()
        {
            SetupCase1();

            var actualResult = waveletAnalyzer.GetAnalysis(values);

            Assert.IsTrue(compareLogic.Compare(expectedResult, actualResult).AreEqual);
        }

        private void SetupCase1()
        {
            values = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9, 9, 9, 9, 3, 2, 7, 5, 2, 8, 2, 55, 2, 7, 3, 1, 6, 9, 1, 3, 2, 66 };

            expectedResult = new WaveletAnalysisCollection
            {
                RearrangedLow = new List<double> {
                    1.333641,
                    3.073267,
                    5.000000,
                    6.963367,
                    8.833180,
                    8.802874,
                    9.533891,
                    3.550919,
                    5.705122,
                    3.143611,
                    17.770563,
                    17.422570,
                    2.318917,
                    5.911796,
                    2.183380,
                    19.369724
                },
                RearrangedHigh = new List<double>
                {
                    0.250000,
                    0.000000,
                    0.000000,
                    -0.125000,
                    -0.125000,
                    -0.547631,
                    3.767892,
                    -3.484163,
                    0.134913,
                    3.924444,
                    58.557907,
                    2.356987,
                    -4.853240,
                    6.123066,
                    -2.014144,
                    71.067941
                }
            };
        }
    }
}

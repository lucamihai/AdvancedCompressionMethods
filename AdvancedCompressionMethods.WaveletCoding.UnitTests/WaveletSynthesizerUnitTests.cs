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
    public class WaveletSynthesizerUnitTests
    {
        private WaveletSynthesizer waveletSynthesizer;
        private WaveletAnalysisCollection analysisCollection;
        private List<double> expectedResult;
        private CompareLogic compareLogic;

        [TestInitialize]
        public void Setup()
        {
            waveletSynthesizer = new WaveletSynthesizer();

            compareLogic = new CompareLogic();
        }

        [TestMethod]
        public void TestThatGetAnalysisReturnsExpectedResult1()
        {
            SetupCase1();

            var actualResult = waveletSynthesizer.GetSynthesis(analysisCollection);

            Assert.IsTrue(compareLogic.Compare(expectedResult, actualResult).AreEqual);
        }

        private void SetupCase1()
        {
            analysisCollection = new WaveletAnalysisCollection
            {
                RearrangedLow = new List<double>
                {
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

            expectedResult = new List<double>
            {
                1.000000,
                2.000000,
                3.000000,
                4.000000,
                5.000000,
                6.000000,
                7.000000,
                8.000000,
                9.000000,
                9.000000,
                9.000000,
                9.000000,
                9.000000,
                9.000000,
                3.000000,
                2.000000,
                7.000000,
                5.000000,
                2.000000,
                8.000000,
                2.000000,
                55.000000,
                2.000000,
                7.000000,
                3.000000,
                1.000000,
                6.000000,
                9.000000,
                1.000000,
                3.000000,
                2.000000,
                66.000000

            };
        }
    }
}

using System;
using System.Linq;
using NUnit.Framework;

namespace StringCalcKata
{
    [TestFixture]
    public class StringCalcKataTests
    {
        public StringCalculator Calculator;

        [TestFixtureSetUp]
        public void CreateCalculator()
        {
            Calculator = new StringCalculator();
        }

        [TestCase("", 0)]
        [TestCase("1,1", 2)]
        [TestCase("2,2", 4)]
        [TestCase("4,8", 12)]
        [TestCase("172,28", 200)]
        public void CalculateTwoNumberSum(string sum, int expected)
        {
            var result = Calculator.Add(sum);
            Assert.AreEqual(expected, result);
        }

        [TestCase("2,2,2", 6)]
        [TestCase("8,16,32", 56)]
        [TestCase("8,16,32,64,128", 248)]
        public void CalculateAnyNumberSum(string sum, int expected)
        {
            var result = Calculator.Add(sum);
            Assert.AreEqual(expected, result);
        }

        [TestCase("2\n2,2", 6)]
        [TestCase("8,16\n32", 56)]
        [TestCase("8,16\n32,64\n128", 248)]
        public void CalculateAnyNumberSumWithNewLine(string sum, int expected)
        {
            var result = Calculator.Add(sum);
            Assert.AreEqual(expected, result);
        }


        [TestCase("//;\n2;2;2", 6)]
        [TestCase("// \n8 16 32", 56)]
        [TestCase("//+\n8+16+32+64+128", 248)]
        [TestCase("//split\n2split2", 4)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        public void CalculateAnyNumberSumWithDelimiterDefined(string sum, int expected)
        {
            var result = Calculator.Add(sum);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalculatingWithANegativeNumber_ReturnsException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Calculator.Add("1,-1"));
            Assert.AreEqual("Negatives are not allowed.", exception.Message.Split('\r').First());
        }

        [Test]
        public void CalculatingWithANumberOverAThousandIgnoresTheNumber()
        {
            var result = Calculator.Add("2,1001");
            Assert.AreEqual(2, result);
        }
    }
}
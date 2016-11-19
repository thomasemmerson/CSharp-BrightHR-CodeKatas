using NUnit.Framework;

namespace RomanKata
{
    [TestFixture]
    public class RomanKataTests
    {
        private NumberConverter _converter;

        [TestFixtureSetUp]
        public void NumberConverterSetup()
        {
            _converter = new NumberConverter();
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]

        public void Arabic_To_Roman(int arabic, string expected)
        {
            var result = _converter.ToRoman(arabic);
            Assert.AreEqual(expected, result);
        }

    }
}
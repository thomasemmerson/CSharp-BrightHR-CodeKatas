using System;
using NUnit.Framework;

namespace SweetAssKata
{
    [TestFixture]
    public class SweetAssKataTests
    {
        private const string Word = "ass";
        private readonly string[] _adjectives = { "sweet", "nice", "cool" };
        private readonly string[] _nouns = { "car", "bike", "train" };

        [TestCase("sweet-ass car", "sweet ass-car")]
        [TestCase("nice-ass car", "nice ass-car")]
        [TestCase("Man, that's a sweet-ass car.", "Man, that's a sweet ass-car.")]
        [TestCase("Man, that sweet-ass car is a nice-ass vehicle.", "Man, that sweet ass-car is a nice ass-vehicle.")]
        [TestCase("Man, that sweet-ass car is a nice-ass vehicle.", "Man, that sweet ass-car is a nice ass-vehicle.")]
        public void SentenceMatchesPattern_HyphenIsMoved(string sentence, string expected)
        {
            var result = sentence.MoveHyphen(Word);
            Assert.AreEqual(expected, result);
        }

        [TestCase("Man, that's a sweet ass car.")]
        [TestCase("Man, that's a sweetass car.")]
        [TestCase("Man, that's a sweet car.")]
        [TestCase("-ass car")]
        [TestCase("sweet-ass")]
        public void SentenceDoesNotMatchPattern_HyphenIsNotMoved(string sentence)
        {
            Assert.AreEqual(sentence, sentence.MoveHyphen(Word));
        }

        [Test]
        public void SentenceHasRandomAdjectiveAndNoun_HyphenIsMoved()
        {
            var adjective = GetRandomString(_adjectives);
            var noun = GetRandomString(_nouns);
            var sentence = "Man, that's a " + adjective + "-ass " + noun + ".";
            var result = sentence.MoveHyphen(Word);
            Assert.AreEqual("Man, that's a " + adjective + " ass-" + noun + ".", result);
        }

        private string GetRandomString(string[] strings)
        {
            return strings[new Random().Next(strings.Length)];
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using AmIRepeatingMyselfTests.Properties;

namespace AmIRepeatingMyself.Tests
{
    [TestClass()]
    public class WordCounterTests
    {
        [TestMethod()]
        public void CountsSimpleSentenceWords()
        {
            var expected = new[] {
                new WordOccurances (1, "I"),
                new WordOccurances (1, "hate"),
                new WordOccurances (1, "repeating"),
                new WordOccurances (1, "myself")
            };
            var counter = new WordCounter();
            var actual = counter.CountWordOccurances("I hate repeating myself!");
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void CountsNumbersAsWords()
        {
            var expected = new[] {
                new WordOccurances (1, "I'am"),
                new WordOccurances (1, "18"),
                new WordOccurances (1, "years"),
                new WordOccurances (1, "old")
            };
            var counter = new WordCounter();
            var actual = counter.CountWordOccurances("I'am 18 years old!");
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void CountsSentenceWithRepeatingWords()
        {
            var expected = new[] {
                new WordOccurances (2, "My"),
                new WordOccurances (1, "cat"),
                new WordOccurances (1, "is"),
                new WordOccurances (1, "faster"),
                new WordOccurances (1, "then"),                
                new WordOccurances (1, "dog"),
            };
            var counter = new WordCounter();
            var actual = counter.CountWordOccurances("My cat is faster then my dog.");
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void IgnoresPunctuation()
        {
            var expected = new[] {
                new WordOccurances (2, "Why"),
                new WordOccurances (1, "oh")                
            };
            var counter = new WordCounter();
            var actual = counter.CountWordOccurances("Why, oh why?");
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void HandlesVeryLongSentences()
        {   
            var counter = new WordCounter();
            var actual = counter.CountWordOccurances(Resources.TheLastVoyageOfTheGhostShip);
            var actualWords = actual.Sum(c => c.Occurances);
            Assert.AreEqual(2156, actualWords);
        }
    }
}
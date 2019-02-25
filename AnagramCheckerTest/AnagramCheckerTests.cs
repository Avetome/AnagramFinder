using AnagramCheck;
using Xunit;

namespace AnagramCheckTest
{
    public class AnagramCheckerTests
    {
        [Theory(DisplayName = "Return false if length is different")]
        [InlineData("good", "bad")]
        [InlineData("ugly", "bad")]
        [InlineData("ugly", "555555")]
        public void ShouldReturnFalseIfLengthIsDifferent(string word1, string word2)
        {
            var checker = new AnagramChecker();

            var result = checker.Check(word1, word2);

            Assert.False(result);
        }

        [Theory(DisplayName = "Return false if one string is empty")]
        [InlineData("good", "")]
        [InlineData("", "bad")]
        [InlineData("ugly", "")]
        public void ShouldReturnFalseIfOnStringIsEmpty(string word1, string word2)
        {
            var checker = new AnagramChecker();

            var result = checker.Check(word1, word2);

            Assert.False(result);
        }

        [Theory(DisplayName = "Return false if strings are not anagram each other")]
        [InlineData("good", "ugly")]
        [InlineData("bad", "guy")]
        [InlineData("cat", "rat")]
        public void ShouldReturnFalseIfStringsAreNotAnagram(string word1, string word2)
        {
            var checker = new AnagramChecker();

            var result = checker.Check(word1, word2);

            Assert.False(result);
        }

        [Theory(DisplayName = "Return true if string are not anagram each other")]
        [InlineData("rots", "sort")]
        [InlineData("enlist", "inlets")]
        [InlineData("sinks", "skins")]
        [InlineData("cat", "tac")]
        [InlineData("fresher", "refresh")]
        public void ShouldReturnTrueIfStringsAreAnagram(string word1, string word2)
        {
            var checker = new AnagramChecker();

            var result = checker.Check(word1, word2);

            Assert.True(result);
        }
    }
}

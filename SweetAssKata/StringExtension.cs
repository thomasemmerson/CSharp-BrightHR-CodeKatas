using System.Text.RegularExpressions;

namespace SweetAssKata
{
    public static class StringExtension
    {
        public static string MoveHyphen(this string sentence, string word)
        {
            var beforeHyphenatedWord = "-" + word + " ";
            var afterHyphenatedWord = " " + word + "-";
            var match = Regex.Match(sentence, @"[^\s]+"  + beforeHyphenatedWord + @"[^\s]+");
            return match.Success
                ? sentence.Replace(beforeHyphenatedWord, afterHyphenatedWord)
                : sentence;
        }
    }
}
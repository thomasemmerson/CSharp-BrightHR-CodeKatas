using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class StringCalculator
    {
        private static readonly string[] DefaultDelims = { ",", "\n" };
        private const string DelimStart = "//";
        private const string DelimEnd = "\n";
        private const string DelimWrapStart = @"\[";
        private const string DelimWrapEnd = @"\]";
        private static readonly string[] DelimEnds = { DelimEnd };

        public int Add(string sum)
        {
            if (sum == string.Empty) return 0;
            var calculation = new StringBuilder(sum);
            var total = 0;
            foreach (var number in NumbersFromString(calculation))
            {
                if(number < 0) throw new ArgumentOutOfRangeException(sum, "Negatives are not allowed.");
                if(number > 1000) continue;
                total += number;
            }
            return total;
        }

        private static IEnumerable<int> NumbersFromString(StringBuilder sum)
        {
            var delimiter = ExtractDelimiters(sum);
            return sum.ToString().Split(delimiter, StringSplitOptions.None).Select(number => Convert.ToInt32(number));
        }

        private static string[] ExtractDelimiters(StringBuilder sum)
        {
            var customDelim = Regex.Match(sum.ToString(), @"^" + DelimStart + @"(.*?)" + DelimEnd).Groups[1].Value;
            if (customDelim.Length == 0) return DefaultDelims;
            sum.Remove(0, DelimStart.Length + DelimEnd.Length + customDelim.Length);
            var multipleDelims = Regex.Matches(customDelim, DelimWrapStart + @"(.*?)" + DelimWrapEnd).Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
            return multipleDelims.Length > 0
                ? multipleDelims
                : new[] {customDelim};
        }
    }
}
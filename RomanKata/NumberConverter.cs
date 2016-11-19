using System.Text;

namespace RomanKata
{
    public class NumberConverter
    {

        public string ToRoman(int number)
        {
            var result = new StringBuilder();
            if (number == 4)
            {
                result.Append("IV");
            }
            else
            {
                for (int i = 0; i < number; i++)
                {
                    result.Append("I");
                }
            }
            return result.ToString();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    public class StringCaluclator
    {
        public static int Calculate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            char? customSeparator = str.StartsWith("//") && str[3] == '\n' ? str[2] : null;



            var split = customSeparator.HasValue ?
                str.Substring(4).Split(',', '\n', customSeparator.Value) :
                str.Split(',', '\n');

            int sum = 0;
            foreach (string s in split)
            {
                if (int.TryParse(s, out var parsed))
                {
                    if (parsed < 0)
                        throw new ArgumentException();
                    if (parsed <= 1000)
                        sum += parsed;
                }
                else
                    return 0;
            }
            return sum;
        }
    }
}

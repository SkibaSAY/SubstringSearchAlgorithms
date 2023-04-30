using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms.Class
{
    public class SuperBrutForce : ISustringSearcher
    {
        public int[] IndexOf(string str, int startIndex, string substring)
        {
            var res = new List<int>();
            int n = str.Length;
            int m = substring.Length;

            for (int i = startIndex; i <= n - m; i++)
            {
                var successFlag = true;
                for (var j = 0; j < m; j++)
                {
                    if (str[i + j] != substring[j])
                    {
                        successFlag = false;
                        break;
                    }
                }
                if (successFlag)
                {
                    res.Add(i);
                }
            }
            return res.ToArray();
        }
    }
}

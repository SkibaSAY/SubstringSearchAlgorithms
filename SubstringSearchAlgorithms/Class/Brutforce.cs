using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms.Class
{
    public class Brutforce : ISustringSearcher
    {
        public int[] IndexOf(string str, int startIndex, string substring)
        {
            var res = new List<int>();
            int n = str.Length;
            int m = substring.Length;

            for(int i = startIndex; i < n - m; i++)
            {
                var curSubstring = str.Substring(i, m);
                if(curSubstring == substring)
                {
                    res.Add(i);
                }
            }
            return res.ToArray();
        }

    }
}

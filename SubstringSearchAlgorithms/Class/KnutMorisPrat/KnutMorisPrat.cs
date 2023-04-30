using SubstringSearchAlgorithms.Class.KnutMorisPrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms
{
    public class KnutMorisPrat : ISustringSearcher
    {
        public int[] IndexOf(string str, int startIndex, string substring)
        {
            var result = new List<int>();
            var prefFunc = PrefixFunction<char>.BuildPrefixFunction(substring.ToArray());

            var len = str.Length;
            var subLen = substring.Length;

            var currLen = 0;
            for(var i = startIndex; i < len; i++)
            {
                if(str[i] == substring[currLen])
                {
                    currLen++;

                    //вхождение найдено
                    if (currLen == subLen)
                    {
                        var currIndex = i - subLen + 1;
                        result.Add(currIndex);
                        currLen = 0;
                        i = currIndex;
                    }
                }
                else
                {
                    if(currLen > 0)
                    {
                        currLen = prefFunc[currLen - 1];
                        i--;
                    }
                }
            }

            return result.ToArray();
        }
    }
}

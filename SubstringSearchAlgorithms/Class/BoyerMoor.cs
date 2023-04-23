using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms.Class
{
    public class BoyerMoor: ISustringSearcher
    {
        private Dictionary<char, int> stopSymbolsTable = new Dictionary<char, int>();
        private Dictionary<string, int> suffixTable = new Dictionary<string, int>();

        public int[] IndexOf(string str, int startIndex, string substring)
        {
            var result = new List<int>();
            FillStopSymbols(substring);
            FillSuffixTable(substring);
            int i = substring.Length - 1;
            int strLength = str.Length;
            int substrLength = substring.Length;
            while(i < strLength - substrLength)
            {
                if (!substring.Contains(str[i]))
                {
                    i += substrLength;
                    continue;
                }
                int indexInSubstring = substrLength - 1;
                while (substring[indexInSubstring] == str[i])
                {
                    if (indexInSubstring == 0)
                    {
                        result.Add(i);
                        var stop = stopSymbolsTable[substring[substrLength - 1]];
                        var suffix = suffixTable[substring];
                        i += Math.Max(stop, suffix);
                        break;
                    }
                    indexInSubstring--;
                    i--;
                    
                }
                if(indexInSubstring != 0)
                {
                    var suffix = suffixTable[substring.Substring(indexInSubstring+1)];
                    var stop = stopSymbolsTable[substring[indexInSubstring]];
                    i+= Math.Max(stop, suffix);
                }
            }
            return result.ToArray();
        }

        private void FillStopSymbols(string pattern)
        {
            //тут нет ошибки. Последний символ не берем
            for (int i = pattern.Length - 2; i >=0; i--)
            {
                var currentSymbol = pattern[i];
                if (!stopSymbolsTable.ContainsKey(currentSymbol))
                {
                    stopSymbolsTable.Add(currentSymbol, i);
                }
            }
            if (!stopSymbolsTable.ContainsKey(pattern[pattern.Length-1]))
            {
                stopSymbolsTable.Add(pattern[pattern.Length - 1], pattern.Length);
            }
        }

        private void FillSuffixTable(string pattern)
        {
            var suffix = "";
            suffixTable.Add(suffix, 1);
            var patternLength = pattern.Length;
  
            var trimPattern = pattern;

            int i = 1;
            while (suffix != pattern)
            {
                suffix = pattern[patternLength - i] + suffix;
                trimPattern = trimPattern.Remove(trimPattern.Length-1);
                if (!trimPattern.Contains(suffix))
                {
                    var predSuffix = suffix.Substring(1);
                    if (!trimPattern.Contains(predSuffix))
                    {
                        suffixTable.Add(suffix, suffixTable[predSuffix]);
                    }
                    else
                    {
                        var littleString = trimPattern;
                        while (littleString!="")
                        {
                            if (suffix.EndsWith(littleString)) break;
                            littleString = littleString.Remove(littleString.Length - 1);
                        }
                        suffixTable.Add(suffix, patternLength - littleString.Length);
                    }
                }
                else
                {
                    var littleString = trimPattern.Substring(trimPattern.Length - suffix.Length);
                    for(int j = trimPattern.Length - suffix.Length - 1; j >= 0; j--)
                    {
                        if (littleString.StartsWith(suffix)) break;
                        littleString = trimPattern[j] + littleString;
                    }
                    suffixTable.Add(suffix, littleString.Length);
                }
                i++;
            }
        }
    }
}

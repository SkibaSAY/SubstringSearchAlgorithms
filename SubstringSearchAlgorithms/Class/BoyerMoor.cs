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
            stopSymbolsTable = new Dictionary<char, int>();
            suffixTable = new Dictionary<string, int>();

            var result = new List<int>();
            FillStopSymbols(substring);
            FillSuffixTable(substring);
            int i = substring.Length - 1;
            int strLength = str.Length;
            int substrLength = substring.Length;

            while (i < strLength)
            {
                if (!substring.Contains(str[i]))
                {
                    i += substrLength;
                    continue;
                }
                int indexInSubstring = substrLength - 1;
                int k = i;
                while (substring[indexInSubstring] == str[k])
                {
                    if (indexInSubstring == 0)
                    {
                        result.Add(k);
                        var stop = stopSymbolsTable[substring[substrLength - 1]];
                        var suffix = 0;
                        if (!suffixTable.ContainsKey(substring))
                        {
                            suffix = substrLength;
                        }
                        else
                        {
                            suffix = suffixTable[substring];
                        }
                        i += Math.Max(stop, suffix);
                        indexInSubstring = -1;
                        break;
                    }
                    indexInSubstring--;
                    k--;
                    
                }
                if(indexInSubstring >= 0)
                {
                    var curSuffix = substring.Substring(indexInSubstring + 1);
                    var suffix = 0;
                    if (!suffixTable.ContainsKey(curSuffix))
                    {
                        suffix = substrLength;
                    }
                    else
                    {
                        suffix = suffixTable[substring.Substring(indexInSubstring + 1)];
                    }
                    if (k != i) k++;
                    var stop = stopSymbolsTable[str[k]];
                    i+= Math.Max(stop, suffix);
                }
            }
            return result.ToArray();
        }

        private void FillStopSymbols(string pattern)
        {
            //тут нет ошибки. Последний символ не берем
            var ptternLengthMinus1 = pattern.Length - 1;
            for (int i = ptternLengthMinus1 - 1; i >=0; i--)
            {
                var currentSymbol = pattern[i];
                if (!stopSymbolsTable.ContainsKey(currentSymbol))
                {
                    stopSymbolsTable.Add(currentSymbol, ptternLengthMinus1 - i);
                }
            }
            if (!stopSymbolsTable.ContainsKey(pattern[ptternLengthMinus1]))
            {
                stopSymbolsTable.Add(pattern[ptternLengthMinus1], ptternLengthMinus1 + 1);
            }
        }

        private void FillSuffixTable(string pattern)
        {
            var suffix = "";
            suffixTable.Add(suffix, 1);
            var patternLength = pattern.Length;
  
            var trimPattern = pattern;
            var predSuffix = "";
            int i = 1;
            while (suffix != pattern)
            {
                suffix = pattern[patternLength - i] + suffix;
                if (suffixTable[predSuffix] == patternLength)
                {
                    suffixTable.Add(suffix, patternLength);
                    i++;
                    predSuffix = suffix;
                    break;
                }
                trimPattern = trimPattern.Remove(trimPattern.Length-1);
                if (!trimPattern.Contains(suffix))
                {
                    var littleString = suffix.Substring(1, suffix.Length - 1);
                    var littlePattern = pattern.Substring(0, patternLength - 1);
                    while (littleString != "")
                    {
                        if (littlePattern.StartsWith(littleString)) break;
                        littleString = littleString.Remove(0, 1);
                    }
                    suffixTable.Add(suffix, patternLength - littleString.Length); 
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
                predSuffix = suffix;
            }
        }
    }
}

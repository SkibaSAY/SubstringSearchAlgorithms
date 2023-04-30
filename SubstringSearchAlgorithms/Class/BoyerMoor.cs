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
            var stopLastInSubstr = stopSymbolsTable[substring[substrLength - 1]];
            var suffixOfSubstr = substrLength;
            if (suffixTable.ContainsKey(substring)) suffixOfSubstr = suffixTable[substring];
            var addingIndex = Math.Max(stopLastInSubstr, suffixOfSubstr);

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
                        i += addingIndex;
                        indexInSubstring = -1;
                        break;
                    }
                    indexInSubstring--;
                    k--; 
                }
                if(indexInSubstring >= 0)
                {
                    var curSuffix = substring.Substring(indexInSubstring + 1);
                    var suffix = substrLength;
                    if (suffixTable.ContainsKey(curSuffix))
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
            var patternMinus1 = pattern.Substring(0, patternLength - 1);

            var predSuffix = "";
            var trimPattern = pattern;
            int currentIndex = patternLength - 1;
            while (suffix != pattern)
            {
                suffix = pattern[currentIndex] + suffix;
                trimPattern = trimPattern.Remove(trimPattern.Length-1);
                if (!trimPattern.Contains(suffix))
                {
                    var littleString = predSuffix;

                    while (littleString != "")
                    {
                        if (patternMinus1.StartsWith(littleString)) break;
                        littleString = littleString.Remove(0, 1);
                    }
                    suffixTable.Add(suffix, patternLength - littleString.Length); 
                }
                else
                {
                    var littleString = trimPattern;
                    int position = littleString.IndexOf(suffix);
                    int suffxLength = suffix.Length;
                    int newPosition = position;
                    while (littleString.Length >= suffxLength)
                    {
                        littleString = littleString.Remove(0, newPosition + 1);
                        newPosition = littleString.IndexOf(suffix);
                        if (newPosition > 0) position += newPosition + 1;
                        else break;
                    }
                    suffixTable.Add(suffix, suffxLength - position);
                }
                if (suffixTable[suffix] == patternLength)
                {
                    break;
                }
                currentIndex--;
                predSuffix = suffix[0] + predSuffix;
            }
        }
    }
}

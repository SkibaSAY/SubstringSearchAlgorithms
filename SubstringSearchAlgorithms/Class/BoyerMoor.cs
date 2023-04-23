using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms.Class
{
    class BoyerMoor
    {
        private Dictionary<char, int> stopSymbolsTable = new Dictionary<char, int>();
        private Dictionary<string, int> suffixTable = new Dictionary<string, int>();

        private void FillStopSymbols(string pattern)
        {
            //тут нет ошибки. Последний символ не берем
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                var currentSymbol = pattern[i];
                if (stopSymbolsTable.ContainsKey(currentSymbol))
                {
                    stopSymbolsTable[currentSymbol] = i + 1;
                }
                else
                {
                    stopSymbolsTable.Add(currentSymbol, i + 1);
                }
            }
        }

        private void FillSuffixTable(string pattern)
        {
            var suffix = "";
            suffixTable.Add(suffix, 1);
            suffix += pattern[pattern.Length - 1];
            int i = 1;
            while (suffix != pattern)
            {

            }
        }
    }
}

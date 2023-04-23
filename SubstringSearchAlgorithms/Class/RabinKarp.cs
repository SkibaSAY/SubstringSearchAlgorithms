using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms.Class
{
    public class RabinKarp : ISustringSearcher
    {
        private int _primaryNumber = 14969;
        private int toNextSdvig = 8;
        public readonly int _alphavitCapasity = 256;

        public int[] IndexOf(string str, int startIndex, string substring)
        {
            var foundedIndxs = new List<int>();
            var n = str.Length;
            var m = substring.Length;
            var _helpSdvig = (m - 1) * toNextSdvig - 1;

            var preparedResult = 0;

            //считаем значение для подстроки отдельно
            for (var i = 0; i < m; i++)
            {
                var next = (int)substring[i];
                preparedResult = ComputeSubstringRateNext(next, preparedResult, _helpSdvig);
            }

            var tempResult = 0;
            for(var i = 0; i < n; i++)
            {
                var next = (int)str[i];
                tempResult = ComputeSubstringRateNext(next, tempResult, _helpSdvig);
                if(tempResult == preparedResult && i >= m-1)
                {
                    var start = i - (m - 1);
                    var aplicant = str.Substring(start, m);
                    if (substring.Equals(aplicant))
                    {
                        foundedIndxs.Add(start);
                    }                   
                }
            }

            return foundedIndxs.ToArray();
        }
        private int ComputeSubstringRateNext(int next,int currentResult, int helpSdvig)
        {
            //отрезаем левую часть
            currentResult = currentResult & helpSdvig;
            //сдвигаемся, чтобы освободить место для нового разряда
            currentResult = currentResult << toNextSdvig;
            //добавляем новый разряд
            currentResult += next;
            return currentResult % _primaryNumber;
        }
    }
}

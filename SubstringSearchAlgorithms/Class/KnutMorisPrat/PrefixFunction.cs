using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms.Class.KnutMorisPrat
{
    public static class PrefixFunction<T>
                where T : IComparable<T>
    {
        public static int[] BuildPrefixFunction(T[] items,Comparer<T> comparer = null)
        {
            if (comparer == null) comparer = Comparer<T>.Default;
            var len = items.Length;
            var result = new int[len];

            for (var i = 1; i < len; i++)
            {
                var suffixLen = result[i - 1];
                var flag = comparer.Compare(items[i], items[suffixLen]);
                while (suffixLen > 0 && flag != 0)
                {
                    suffixLen = result[suffixLen - 1];
                    flag = comparer.Compare(items[i], items[suffixLen]);
                }
                if (flag == 0)
                {
                    suffixLen++;
                }
                result[i] = suffixLen;
            }

            return result;
        }
    }
}

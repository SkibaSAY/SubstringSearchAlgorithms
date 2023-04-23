using System;

namespace SubstringSearchAlgorithms
{
    public interface ISustringSearcher
    {
        public int[] IndexOf(string str,int startIndex,string substring);
    }
}

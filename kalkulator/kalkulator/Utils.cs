using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator
{
    static class Utils
    {
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> elements)
        {
            foreach(var e in elements)
            {
                hashSet.Add(e);
            }
        }



    }
}

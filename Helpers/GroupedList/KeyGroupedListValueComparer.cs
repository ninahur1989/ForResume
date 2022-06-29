using System;
using System.Collections.Generic;
using Modul_3_2_HW.Models;

namespace Modul_3_2_HW.Helpers.GropedList
{
    public class KeyGroupedListValueComparer<T> : IComparer<KeyValuePair<string, List<T>>>
       where T : IGroupedListValue
    {

        public int Compare(KeyValuePair<string, List<T>> x, KeyValuePair<string, List<T>> y)
        {
           return x.Key.ToUpper().CompareTo(y.Key.ToUpper());
        }
    }
}

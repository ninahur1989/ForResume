using System;
using System.Collections.Generic;
using Modul_3_2_HW.Models;

namespace Modul_3_2_HW.Helpers.GropedList
{
    public class GroupedListValueComparer<T> : IComparer<T>
        where T: IGroupedListValue
    {

        public int Compare(T x, T y)
        {
            return x.GroupBy.ToUpper().CompareTo(y.GroupBy.ToUpper());
        }
    }
}

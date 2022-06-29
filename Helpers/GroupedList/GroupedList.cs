using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Modul_3_2_HW.Helpers.GropedList
{
    public class GroupedList<T> : IReadOnlyCollection<KeyValuePair<string, List<T>>>
        where T: IGroupedListValue
    {
        private const string OutOfAlphabet = "#";
        private const string Digits = "0-9";
        private readonly Regex _regexIsDigit = new Regex(@"^\d$");

        private List<KeyValuePair<string, List<T>>> _groupedList;
        private string _alphabet;

        public GroupedList(string alphabet)
        {
            _alphabet = alphabet;
            _groupedList = new List<KeyValuePair<string, List<T>>>();
        }

        public void ChangeAlhabet(string alphabet)
        {
            _alphabet = alphabet;

            var newList = new List<KeyValuePair<string, List<T>>>(_groupedList);
            _groupedList = new List<KeyValuePair<string, List<T>>>();

            foreach (var item in newList)
            {
                foreach (var listOfItem in item.Value)
                {
                    Add(listOfItem);
                }
            }
        }

        public int Count => _groupedList.Count;

        public void Add(T item)
        {
            var firstLetter = item.GroupBy[0].ToString();
            
            if (_regexIsDigit.IsMatch(firstLetter))
            {
                AddItem(Digits, item);
                return;
            }

            foreach (var letter in _alphabet)
            {
                if (letter.ToString().ToUpper() == firstLetter.ToUpper())
                {
                    AddItem(firstLetter, item);
                    return;
                }
            }

            AddItem(OutOfAlphabet, item);
        }

        public void Remove(T item)
        {
            for (int i = 0; i < _groupedList.Count; i++)
            {
                _groupedList[i].Value.Remove(item);
            }
        }

        private void AddItem(string keyName, T item)
        {
            var key = keyName.ToUpper();

            var isExist = IndexKey(key, out var index);

            if (isExist)
            {
                _groupedList[index].Value.Add(item);
                _groupedList[index].Value.Sort(new GroupedListValueComparer<T>());
            }
            else
            {
                _groupedList.Add(new KeyValuePair<string, List<T>>(key, new List<T> { item }));
                _groupedList.Sort(new KeyGroupedListValueComparer<T>());
            }
        }

        public bool IndexKey(string key, out int index)
        {
            index = 0;

            for (int i = 0; i < _groupedList.Count; i++)
            {
                if (key.ToUpper() == _groupedList[i].Key.ToUpper())
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        IEnumerator<KeyValuePair<string, List<T>>> IEnumerable<KeyValuePair<string, List<T>>>.GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        private IEnumerator<KeyValuePair<string, List<T>>> GetGenericEnumerator()
        {
            foreach (var item in _groupedList)
            {
                yield return item;
            }
        }
    }
}

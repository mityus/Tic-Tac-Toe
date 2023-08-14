using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IItemsDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> ItemsDictionary { get; }

        public void AddItem(TKey key, TValue value);
        public void ShowElements();
        public void SetValue(TKey key, TValue value);
        public string GetValue(TKey key);
        public bool IsContainsKey(TKey key);
    }
}
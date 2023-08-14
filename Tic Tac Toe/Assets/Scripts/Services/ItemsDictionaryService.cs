using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class ItemsDictionaryService : IItemsDictionary<Vector3, string>
    {
        private readonly Dictionary<Vector3, string> _itemsDictionary = new Dictionary<Vector3, string>();

        public Dictionary<Vector3, string> ItemsDictionary => _itemsDictionary;

        public void AddItem(Vector3 position, string value)
        {
            _itemsDictionary[position] = value;
        }

        public void ShowElements()
        {
            foreach (var (key, value) in _itemsDictionary) 
            { 
                Debug.Log($"Key: {key}  Value: {value}");
            }
        }

        public List<Vector3> GroupItems()
        {
            return _itemsDictionary.GroupBy(pair => new{pair.Value})
                .Where(group =>
                {
                    var commonX = group.All(pair => pair.Key.x == group.First().Key.x);
                    var commonY = group.All(pair => pair.Key.y == group.First().Key.y);
                    return commonX || commonY;
                })
                .Where(group => group.Count() >= 3)
                .SelectMany(group => group)
                .Select(pairs => pairs.Key)
                .ToList();
        }
    
        public void SetValue(Vector3 position, string newValue)
        {
            if (_itemsDictionary.ContainsKey(position)) _itemsDictionary[position] = newValue;
            else throw new Exception("No such key exists");
        }
        
        public string GetValue(Vector3 position)
        {
            if (_itemsDictionary.TryGetValue(position, out string value)) return value;
            
            return null;
        }

        public bool IsContainsKey(Vector3 position)
        {
            if (_itemsDictionary.ContainsKey(position)) return true;

            return false;
        }
    }
}
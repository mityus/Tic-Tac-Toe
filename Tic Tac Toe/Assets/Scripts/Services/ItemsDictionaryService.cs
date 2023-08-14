using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class ItemsDictionaryService : IItemsDictionary
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
    }
}
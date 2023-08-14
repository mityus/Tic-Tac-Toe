using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IItemsDictionary
    {
        Dictionary<Vector3, string> ItemsDictionary { get; }

        void AddItem(Vector3 position, string value);
        void ShowElements();
        List<Vector3> GroupItems();
    }
}
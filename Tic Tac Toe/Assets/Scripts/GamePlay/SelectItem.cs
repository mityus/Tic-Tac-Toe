using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class SelectItem : MonoBehaviour
    {
        [SerializeField] private Sprite zeroSprite;
        [SerializeField] private Sprite crossSprite;

        [SerializeField] private GameObject item;
        
        private bool _isCrossItem;
        
        private void Start()
        {
            _isCrossItem = true;
        }

        public void MakeMove(Vector3 itemPosition)
        {
            GameObject newItem = Instantiate(item, itemPosition, Quaternion.identity);
            SpriteRenderer spriteRenderer = newItem.GetComponent<SpriteRenderer>();
        
            spriteRenderer.sprite = _isCrossItem ? crossSprite : zeroSprite;
            newItem.name = _isCrossItem ? "Cross" : "Zero";
            _isCrossItem = !_isCrossItem;
            
            GameManager.Instance.ItemsData.ItemsDictionary.SetValue(new Vector3((int)Math.Floor(newItem.transform.position.x), 
                (int)Math.Floor(newItem.transform.position.y), 0), newItem.name);
        }
    }
}
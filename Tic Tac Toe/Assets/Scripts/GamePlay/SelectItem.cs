using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class SelectItem : MonoBehaviour
    {
        public static SelectItem Instance { get; private set; }
        
        [SerializeField] private Sprite zeroSprite;
        [SerializeField] private Sprite crossSprite;

        [SerializeField] private GameObject item;
        
        private bool _isCrossItem;

        private readonly Dictionary<Vector3, string> _itemsDictionary = new Dictionary<Vector3, string>(); // включить зависимость

        public Dictionary<Vector3, string> ItemsDictionary => _itemsDictionary; // переделать

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);
        }

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
            
            _itemsDictionary[new Vector3((int)Math.Floor(newItem.transform.position.x), 
                (int)Math.Floor(newItem.transform.position.y), 0)] = newItem.name;
        }
    }
}
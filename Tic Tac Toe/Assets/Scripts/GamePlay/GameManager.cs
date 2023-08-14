using System;
using Board;
using Interfaces;
using Services;
using UnityEngine;


namespace GamePlay
{
    using ItemsData;
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [SerializeField] private BoardView boardView;
        
        private BoardController _boardController;
        private ItemsData _itemsData;

        public ItemsData ItemsData => _itemsData;

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
            var matchesPositionsList = new ItemsDictionaryService();
            var itemsDictionary = new ItemsDictionaryService();
            
            _itemsData = new ItemsData(matchesPositionsList, itemsDictionary);
            _boardController = new BoardController(boardView);
        }
    }
}
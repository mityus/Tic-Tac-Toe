using System;
using Board;
using UnityEngine;

namespace GamePlay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoardView boardView;
        
        private BoardController _boardController;

        private void Start()
        {
            _boardController = new BoardController(boardView);
        }
    }
}
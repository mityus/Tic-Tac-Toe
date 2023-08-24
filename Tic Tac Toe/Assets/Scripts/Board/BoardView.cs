using System;
using GamePlay;
using Interfaces;
using Unity.Mathematics;
using UnityEngine;

namespace Board
{
    public class BoardView : MonoBehaviour, IBorderView
    {
        [SerializeField] private GameObject cellPrefab;
        [SerializeField] private Transform parentCellContainer;
        
        [Space]
        [Range(0.0f, 2.0f)]
        [SerializeField] private float distanceBetweenCells = 1.1f;

        private GameObject[,] _cells;
       
        public void RenderBoard(int size)
        {
            _cells = new GameObject[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    GameObject cell = Instantiate(cellPrefab, new Vector3(distanceBetweenCells * row - distanceBetweenCells, 
                        distanceBetweenCells * column - distanceBetweenCells, 0), Quaternion.identity, parentCellContainer);

                    cell.name = "Cell_" + row + "_" + column;

                    Vector3 cellPosition = cell.transform.position;
                    
                    GameManager.Instance.ItemsData.ItemsDictionary.AddItem(
                        new Vector3((int)Math.Floor(cellPosition.x), (int)Math.Floor(cellPosition.y), 0), 
                        " ");

                    _cells[row, column] = cell;
                }
            }
        }
    }
}
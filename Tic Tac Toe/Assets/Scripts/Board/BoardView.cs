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
        [SerializeField] private Transform panelCells;

        private GameObject[,] _cells;
       
        public void RenderBoard(int size)
        {
            int cellSize = (int) cellPrefab.transform.localScale.x; 
            
            _cells = new GameObject[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    if (row - cellSize == 0 && column - cellSize == 0)
                        panelCells.position = new Vector3(row + -cellSize + (float) row / 10,
                            column - cellSize + (float) column / 10);
                    
                    GameObject cell = Instantiate(cellPrefab, new Vector3(row - cellSize + (float) row / 10, 
                        column - cellSize + (float) column / 10), Quaternion.identity, parentCellContainer);
                     
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
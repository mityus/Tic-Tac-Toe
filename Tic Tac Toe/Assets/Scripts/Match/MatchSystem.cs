﻿using System;
using System.Collections.Generic;
using Board;
using GamePlay;
using UnityEngine;
using System.Linq;

namespace Match
{
    public class MatchSystem
    {
        
        public bool FindMatch(Vector3 currentPosition)
        {
            currentPosition = new Vector3((int)Math.Floor(currentPosition.x), (int)Math.Floor(currentPosition.y), 0);
            
            GameManager.Instance.ItemsData.MatchesPositionsList.AddItem(currentPosition, 
                SelectItem.Instance.ItemsDictionary[currentPosition]);
            
                Vector3[] directions = {
                Vector3.right, Vector3.left, Vector3.up, Vector3.down, 
                new Vector3(1, 1, 0), new Vector3(-1, 1, 0), 
                new Vector3(-1, -1, 0), new Vector3(1, -1, 0), 
            };
            
            foreach (var direction in directions)
            {
                int currentCount = 1;
            
                for (int i = 1; i <= new BoardModel().SizeBoard - 1; i++)
                {
                    Vector3 neighborPosition = currentPosition + direction * i;
                    
                    if (!SelectItem.Instance.ItemsDictionary.ContainsKey(neighborPosition))
                        continue;
                    
                    if (SelectItem.Instance.ItemsDictionary[currentPosition] ==
                        SelectItem.Instance.ItemsDictionary[neighborPosition])
                    {
                        currentCount++;
                    }
                    else
                        break;
                }

                if (currentCount >= 3) return true;
            }
            
            return false;
        }
    }
}
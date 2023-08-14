using System;
using GamePlay;
using Match;
using UnityEngine;

namespace Cell
{
    using EventBus;
    public class Cell : MonoBehaviour
    {
        private bool _isTouch = false;

        private void OnMouseDown()
        {
            if (!_isTouch)
            {
                _isTouch = true;
                GameManager.Instance.SelectItem.MakeMove(transform.position);
                if (new MatchSystem().FindMatch(transform.position))
                    Debug.Log("Win Test");
            }
        }
    }
}
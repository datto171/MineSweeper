using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MineSweeper
{
    public enum StateTile { Hide, Open}

    public class TileComponent : MonoBehaviour
    {
        int x;
        int y;
        int index;
        [SerializeField]
        Text text;

        StateTile currentState = StateTile.Hide;

        public static Action<TileComponent> onInteract;

        bool isMine = false;
        int numberMines = 0;

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log(123);
            }
        }

        public bool GetIsMine()
        {
            return isMine;
        }

        public void SetIsMine(bool value)
        {
            isMine = value;

            //if (isMine)
            //{
            //    SetColor(Color.black);
            //}
        }

        public void ShowBomb()
        {
            SetColor(Color.black);
        }

        public void ShowNumberMinesAround()
        {
            text.text = numberMines + "";
        }

        public void OnHitTile()
        {
            onInteract?.Invoke(this);
        }

        public int GetNumberMines()
        {
            return numberMines;
        }

        public void SetNumberMines(int count)
        {
            
            numberMines = count;
        }


        public StateTile GetStateTile()
        {
            return currentState;
        }

        public void SetStateTile(StateTile state)
        {
            currentState = state;

            if(state == StateTile.Hide)
            {
                SetColor(Color.yellow);
            }
            else
            {
                SetColor(Color.white);
            }
        }

        private void SetColor(Color colorSet)
        {
            var a = this.GetComponent<Image>();
            a.color = colorSet;
        }

        public int GetPosX()
        {
            return x;
        }

        public int GetPosY()
        {
            return y;
        }

        public void SetPosX(int posX)
        {
            x = posX;
        }

        public void SetPosY(int posY)
        {
            y = posY;
        }

        public void SetIndex(int indexTile)
        {
            index = indexTile;
        }

        public void SetTextTile(int x, int y)
        {
            text.text = x + ", " + y;
        }
    }
}

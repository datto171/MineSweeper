using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeper
{
    public class GameContext : MonoBehaviour
    {
        List<TileComponent> listTileClear = new List<TileComponent>();
        List<TileComponent> listCheckAroundZero = new List<TileComponent>();

        private void Awake()
        {
            TileComponent.onInteract = OnInteract;
        }

        public void OnInteract(TileComponent target)
        {
            Debug.Log(target.GetPosX() + ", " + target.GetPosY());

            target.SetStateTile(StateTile.Open);

            if (target.GetIsMine())
            {
                target.ShowBomb();
                Debug.Log("BOMB YOU LOSE");
            }
            else
            {
                if(target.GetNumberMines() == 0)
                {
                    OpenTileAroundZero(target);
                    Debug.Log("Check Tile Around");
                    listTileClear.Clear();
                }
                else
                {
                    Debug.Log("Open Number");
                    target.ShowNumberMinesAround();
                }
                // Set Text Number Mines Arounds
            }

            
        }

        public void OpenTileAroundZero(TileComponent target)
        {
            //target.SetStateTile(StateTile.Open);

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var tileAround = GameManager.Instance.GetTile(target.GetPosX() + i, target.GetPosY() + j);
                    if (tileAround != null)
                    {
                        if(tileAround.GetStateTile() == StateTile.Hide)
                        {
                            //if (listTileClear.Contains(tileAround))
                            //{
                            //    listTileClear.Add(tileAround);
                            //}

                            //if (tileAround.GetNumberMines() == 0)
                            //{
                            //    if (!listCheckAroundZero.Contains(tileAround))
                            //    {
                            //        listCheckAroundZero.Add(tileAround);
                            //    }
                            //}

                            OnInteract(tileAround);
                        }
                    }
                }
            }

            Debug.Log(listTileClear.Count);



            //foreach (TileComponent t in listCheckAroundZero)
            //{
            //    OnInteract(t);
            //    t.SetStateTile(StateTile.Open);
            //    if (t.GetStateTile() == StateTile.Hide)
            //    {
            //        OpenTileAroundZero(t);
            //    }
            //}

            //foreach (TileComponent t in listTileClear)
            //{
            //    //Debug.Log(123);
            //    t.SetStateTile(StateTile.Open);
            //    //OnInteract(t);
            //}

            Debug.Log(listCheckAroundZero.Count);
        }

        public void OpenTile(TileComponent tile)
        {

        }

        public void CheckTilesAround(TileComponent tile)
        {
            int numbMines = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var tileAround = GameManager.Instance.GetTile(tile.GetPosX() + i, tile.GetPosY() + j);
                    if (tileAround != null)
                    {
                        if (tileAround.GetIsMine())
                        {
                            numbMines++;
                        }
                    }
                }
            }

            GameManager.Instance.GetTile(tile.GetPosX(), tile.GetPosY()).SetNumberMines(numbMines);
        }
    }
}
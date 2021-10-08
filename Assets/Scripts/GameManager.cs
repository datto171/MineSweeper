using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeper
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField]
        int size = 10;

        [SerializeField]
        int numberMines = 10;
        int numberFlags ;

        [SerializeField]
        GameObject gridTile;

        TileComponent[] cells;

        [SerializeField]
        GameContext gameContext;

        private void Start()
        {
            numberFlags = numberMines;

            Instance = this;
            SetIndexMap();
            SetupMap();
        }


        public void SetIndexMap()
        {
            cells = gridTile.GetComponentsInChildren<TileComponent>();

            for(int i = 0; i < cells.Length; i++)
            {
                cells[i].SetPosX(i % size);
                cells[i].SetPosY(i / size);
                cells[i].SetIndex(i);
                cells[i].SetTextTile(i % size, i / size);

                cells[i].SetStateTile(StateTile.Hide);
            }
        }

        public TileComponent GetTile(int x, int y)
        {
            if(x > (size - 1) || x < 0 || y > (size - 1) || y < 0)
            {
                return null;
            }
            else
            {
                return cells[y * size + x];
            }
        }

        public void ShowFullMap()
        {

        }

        public void SetupMap()
        {
            SetupMines();
            SetupNumbers();
        }

        public void SetupMines()
        {
            for (int i = 0; i < numberMines; i++)
            {
                var x = Random.Range(0, size);
                var y = Random.Range(0, size);

                GetTile(x, y).SetIsMine(true);
                //GetTile(x, y).SetStateTile(StateTile.Mine);
            }
        }

        public void SetupNumbers()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if(!cells[i].GetIsMine())
                {
                    gameContext.CheckTilesAround(cells[i]);
                }
            }
        }

        
    }
}

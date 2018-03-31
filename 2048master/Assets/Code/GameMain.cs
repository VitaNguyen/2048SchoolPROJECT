using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour {


    private Tile[,] Tiles = new Tile[4, 4];
    List<Tile[]> TableTile = new List<Tile[]>();

    void Start()
    {
        //This line returns the numbers of Tiles in the Scene which is on the UI (Total:16)
        Tile[] AllTilesAtOnce = GameObject.FindObjectsOfType<Tile>(); //this method is used to get all the tiles in our scene when it starts. But this array will be gone out of this method Start()
        for (int i = 0; i < AllTilesAtOnce.Length; i++)
        {
            AllTilesAtOnce[i].Appear=0;
            Tiles[AllTilesAtOnce[i].Row, AllTilesAtOnce[i].Column] = AllTilesAtOnce[i];
            Debug.Log(AllTilesAtOnce[i].Row+ " "+ AllTilesAtOnce[i].Column + " "+i);
        }

        Generate();
    }

    void Update()
    {
       
    }
    
    void Generate()
    {
            int i = UnityEngine.Random.Range(0, 4);
            int j = UnityEngine.Random.Range(0, 4);

            if (Tiles[i, j].Appear == 0)
            {
                Tiles[i, j].Appear = UnityEngine.Random.Range(1, 2);
            }
            else if (Tiles[i, j].Appear != 0)
            {
            Generate();
            }

    }


    void MoveToLeft(Tile[,] a)
    {
        int n = 5;
        while (n != 1)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (a[i, j].Appear != 0 && a[i, j - 1].Appear == 0)
                    {
                        a[i, j - 1].Appear = a[i, j].Appear;
                        a[i, j].Appear = 0;
                    }
                     if (a[i, j].Appear == a[i, j - 1].Appear && a[i, j-1].Appear != 0 && a[i, j].Appear != 0)
                    {
                        a[i, j -1].Appear = a[i, j - 1].Appear +1;
                        
                        a[i, j].Appear = 0;
                    }
                 }
            }
                    n--;
        }
    }
   

    void RotateLeft()
    {
        Tile[,] temp = new Tile[4,4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                temp[i, j]= Tiles[i, j];
                
            }
        }
      
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Tiles[i,j] = temp[4 - j - 1, i];
            }
        }
        
    }

    void RotateRight()
    {
        Tile[,] temp = new Tile[4, 4];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                temp[i, j] = Tiles[i, j];
                
            }
        }
        
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Tiles[i,j] = temp[j, 4 - i - 1];   
            }
        }
    }

    void MoveLeft()
    {
            MoveToLeft(Tiles);     
    }

    void MoveRight()
    {
        RotateLeft();
        RotateLeft();
        MoveToLeft(Tiles);
        RotateRight();
        RotateRight();

    }

    void MoveUp()
    {
        RotateRight();
        MoveLeft();
        RotateLeft();
    }

    void MoveDown()
    {
        RotateLeft();
        MoveLeft();
        RotateRight();
    }

    public void Move(Direction d)
    {
        Debug.Log(d.ToString() + " move.");
            switch (d)
            {
                case Direction.Up:
                    MoveUp();
                    break;
                case Direction.Down:
                    MoveDown();
                    break;
                case Direction.Right:
                    MoveRight();
                    break;
                case Direction.Left:
                    MoveLeft();
                    break;
            }
        Generate();
        
    }

   
}

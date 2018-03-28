using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {


    private Tile[,] Tiles = new Tile[4, 4];

     void Start()
    {
        //This line returns the numbers of Tiles in the Scene which is on the UI (Total:16)
        Tile[] AllTilesAtOnce = GameObject.FindObjectsOfType<Tile>(); //this method is used to get all the tiles in our scene when it starts. But this array will be gone out of this method Start()
        
        for(int i = 0; i < AllTilesAtOnce.Length; i++)
        {
            AllTilesAtOnce[i].Appear=0;
            Tiles[AllTilesAtOnce[i].Row, AllTilesAtOnce[i].Column] = AllTilesAtOnce[i];
            Debug.Log(AllTilesAtOnce[i]);
        }
    }

    void Update()
    {
        
    }


    public void Move(Direction d)
    {
        Debug.Log(d.ToString() + " move.");
    }

   
}

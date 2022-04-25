using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandler
{
    private static int tileNum = 0;
    private static int totalTileTypes = 14;
    private static int maxTileNum = 20;
    private static int gridSize = 25;
    private static Slots[,] spawnGrid;

    public static void setSlotXY() 
    {
        for(int rcount = 0; rcount < gridSize;) 
        {
            for(int ccount = 0; ccount < gridSize;) 
            {
                Debug.Log(rcount + ", " + ccount);
                spawnGrid[rcount, ccount].setPos(ccount, rcount);
                ccount++;
            }
            rcount++;
        }
    } 

    public static int GetTileNum()
    {
        return tileNum;
    }
    //public static void SetTileNum(int val)
    //{
    //    tileNum = val;
    //}
    public static void AddTile()
    {
        tileNum++;
    }

    public static int GetTotalTypesNum()
    {
        return totalTileTypes;
    }

    public static int GetMaxTiles()
    {
        return maxTileNum;
    }

    public static Slots getSpawnCoordVal(int x, int y) 
    {
        return spawnGrid[y, x];
    }
    public static void setSpawnCoordVal(int x, int y, Slots val) 
    {
        spawnGrid[y, x] = val;
    }

    public static Slots[,] getSpawnGrid() 
    {
        return spawnGrid;
    }
    public static void setSpawnGrid(int size) 
    {
         spawnGrid = new Slots[size,size];
    }

    public static int getGridSize() 
    {
        return gridSize;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandler
{
    private static int tileNum = 0;
    private static int totalTileTypes = 14;
    private static int maxTileNum = 20;
    //private static int gridSize = 25;
    //private static Slots[,] spawnGrid;
    private static int score = 0;
    private static Vector3[] coordsStore = new Vector3[maxTileNum + 2];
    private static int storePointer = 0;

    //public static void setSlotXY() 
    //{
    //    for(int rcount = 0; rcount < gridSize;) 
    //    {
    //        for(int ccount = 0; ccount < gridSize;) 
    //        {
    //            Debug.Log(rcount + ", " + ccount);
    //            spawnGrid[rcount, ccount].setPos(ccount, rcount);
    //            ccount++;
    //        }
    //        rcount++;
    //    }
    //} 

    //Gets the current number of tiles
    public static int GetTileNum()
    {
        return tileNum;
    }
    //Adds one to the current value for number of tiles
    public static void AddTile()
    {
        tileNum++;
    }

    //gets the total number of the types of tiles
    public static int GetTotalTypesNum()
    {
        return totalTileTypes;
    }

    //Gets the value for the maximum number of tiles allowed to be spawned.
    public static int GetMaxTiles()
    {
        return maxTileNum;
    }

    //public static Slots getSpawnCoordVal(int x, int y) 
    //{
    //    return spawnGrid[y, x];
    //}
    //public static void setSpawnCoordVal(int x, int y, Slots val) 
    //{
    //    spawnGrid[y, x] = val;
    //}

    //public static Slots[,] getSpawnGrid() 
    //{
    //    return spawnGrid;
    //}
    //public static void setSpawnGrid(int size) 
    //{
    //     spawnGrid = new Slots[size,size];
    //}

    //public static int getGridSize() 
    //{
    //    return gridSize;
    //}

    //returns the current score
    public static int getScore() 
    {
        return score;
    }
    //sets the current score
    public static void setScore(int scoreIn) 
    {
        score = scoreIn;
    }
    //adds one to the current score
    public static void addScore(int addScore) 
    {
        Debug.Log("Adding Score");
        score = score + addScore;
    }

    //adds a coordinate to the bottom of the array
    public static void addCoord(Vector3 coord) 
    {
        coordsStore[storePointer] = coord;
        storePointer++;
    }
    
    //gets a coordinate from/at a given index
    public static Vector3 getCoord(int i) 
    {
        return coordsStore[i];
    }

    //gets the current value of the pointer
    public static int getCoordPointer() 
    {
        return storePointer;
    }
}

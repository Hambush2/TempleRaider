using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHandler
{
    private static int tileNum = 0;
    private static int totalTileTypes = 14;
    private static int maxTileNum = 20;

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
}

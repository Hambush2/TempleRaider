using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots
{
    Slots[] neighbourSlots; // 0 = forward/up; 1 = right; 2 = back; 3 = left;
    bool[] validNeighbours;
    bool[] connectedNeighbours;
    int xPos;
    int yPos;
    GameObject Tile = null;

    //Constructors
    public Slots()
    {

    }

    public Slots(int x, int y)
    {
        xPos = x;
        yPos = y;
    }

    public Slots(int x, int y, GameObject inTile) 
    {
        xPos = x;
        yPos = y;
        Tile = inTile;
    }


    //Position getter and setter
    public void setPos(int x, int y)
    {
        xPos = x;
        yPos = y;
    }
    public int[] getPos() 
    {
        int[] coordArr = new int[2];
        coordArr[0] = xPos;
        coordArr[1] = yPos;
        return coordArr;
    }

    //Tile getter and setter
    public void setTile(GameObject inTile) 
    {
        Tile = inTile;
    }
    public GameObject getTile() 
    {
        return Tile;
    }

    //Sets up which slots neighbour this one in the grid
    public void setNeighbourSlots()
    {
        neighbourSlots[0] = DataHandler.getSpawnCoordVal(xPos, yPos + 1);
        neighbourSlots[1] = DataHandler.getSpawnCoordVal(xPos + 1, yPos);
        neighbourSlots[2] = DataHandler.getSpawnCoordVal(xPos, yPos - 1);
        neighbourSlots[3] = DataHandler.getSpawnCoordVal(xPos - 1, yPos - 1);

    }

    //Sets up which directions the tile can connect to
    public void setConnection()
    {
        if (Tile.tag == "ForwardTile")
        {
            connectedNeighbours[0] = true;
            connectedNeighbours[1] = false;
            connectedNeighbours[2] = false;
            connectedNeighbours[3] = false;

        }
        if (Tile.tag == "All4Tile")
        {
            connectedNeighbours[0] = true;
            connectedNeighbours[1] = true;
            connectedNeighbours[2] = true;
            connectedNeighbours[3] = true;
        }
        if (Tile.tag == "DeadTile")
        {
            connectedNeighbours[0] = false;
            connectedNeighbours[1] = false;
            connectedNeighbours[2] = false;
            connectedNeighbours[3] = false;
        }
        if (Tile.tag == "LeftTile")
        {
            connectedNeighbours[0] = false;
            connectedNeighbours[1] = false;
            connectedNeighbours[2] = false;
            connectedNeighbours[3] = true;
        }
        if (Tile.tag == "RightTile")
        {
            connectedNeighbours[0] = false;
            connectedNeighbours[1] = true;
            connectedNeighbours[2] = false;
            connectedNeighbours[3] = false;
        }
        if (Tile.tag == "LeftRightTile")
        {
            connectedNeighbours[0] = false;
            connectedNeighbours[1] = true;
            connectedNeighbours[2] = false;
            connectedNeighbours[3] = true;
        }
        if (Tile.tag == "ForwardLeftTile")
        {
            connectedNeighbours[0] = true;
            connectedNeighbours[1] = false;
            connectedNeighbours[2] = false;
            connectedNeighbours[3] = true;
        }
        if (Tile.tag == "ForwardRightTile")
        {
            connectedNeighbours[0] = true;
            connectedNeighbours[1] = true;
            connectedNeighbours[2] = false;
            connectedNeighbours[3] = false;
        }

        TileRotationAdjust();
    }

    //returns the connections array
    public bool[] getConnections() 
    {
        return connectedNeighbours;
    }

    //Changes the valid connections based on the rotation of the tile
    public void TileRotationAdjust()
    {
        bool holder1;
        bool holder2;

        //if the tile is rotated right
        if(Tile.transform.eulerAngles.y == 90) 
        {
            //storing the right value
            holder1 = connectedNeighbours[1];
            //setting the right value to the forward value (90 degree rotation)
            connectedNeighbours[1] = connectedNeighbours[0];

            //storing the back value
            holder2 = connectedNeighbours[2];
            //setting the back value to the right value
            connectedNeighbours[2] = holder1;

            //storing the left value (can overwrite holder1 since it has given the 'right' value to connectedNeighbours[2]
            holder1 = connectedNeighbours[3];
            //setting the left value to the back value
            connectedNeighbours[3] = holder2;

            //setting the forward value to the left value
            connectedNeighbours[0] = holder1;
        }

        //if the tile is rotated left
        if(Tile.transform.eulerAngles.y == -90) 
        {
            //storing the left value
            holder1 = connectedNeighbours[3];
            //setting  the left value to the forward value
            connectedNeighbours[3] = connectedNeighbours[0];

            //storing the back value
            holder2 = connectedNeighbours[2];
            //setting the back value to the left value
            connectedNeighbours[2] = holder1;

            //storing the right value
            holder1 = connectedNeighbours[1];
            //setting the right value to the back value
            connectedNeighbours[1] = holder2;

            //setting the forward value to the right value
            connectedNeighbours[0] = holder1;

        }
        //if the tile is rotated 180
        if(Tile.transform.eulerAngles.y == 180 || Tile.transform.eulerAngles.y == -180) 
        {
            holder1 = connectedNeighbours[2];
            connectedNeighbours[2] = connectedNeighbours[0];

            connectedNeighbours[0] = holder1;

            holder1 = connectedNeighbours[1];
            connectedNeighbours[1] = connectedNeighbours[3];

            connectedNeighbours[3] = holder1;
        }
    }

    //Sets up which neighbouring slots the tile can lead to, denoting them as valid
    public bool[] ValidSpawns() 
    {
        setNeighbourSlots();
        setConnection();

        for (int count = 0; count < 4;) 
        {
            if (connectedNeighbours[count] && neighbourSlots[count].getTile() == null)
            {
                validNeighbours[count] = true;
            }
            count++;
        }
        return validNeighbours;
    }
}

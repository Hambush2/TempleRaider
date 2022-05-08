using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTurnTileSpawner : MonoBehaviour
{
    public GameObject[] tiles = new GameObject[DataHandler.GetTotalTypesNum()];
    public GameObject deadEnd;


    void Awake()
    {
        //increments the tile count
        DataHandler.AddTile();

        //checks the coordinates array to see if the targeted spot is already occupied and in the number of tiles has not exceeded the maximum
        if (checkCoords() == true && DataHandler.GetTileNum() <= DataHandler.GetMaxTiles())
        {
            NextTileSpawn();
        }
        //if it has reached the maximum number of tiles spawn and there is a free spot, spawn a dead end
        else if (checkCoords() == true)
        {
            Debug.Log("Spawning Dead End");
            Instantiate(deadEnd, this.transform.position + (transform.forward * 4), Quaternion.Euler(0, -90 + this.transform.eulerAngles.y, 0));

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //spawns the next tile
    void NextTileSpawn()
    {
        int val;
        System.Random rand = new System.Random();
        val = rand.Next(0, DataHandler.GetTotalTypesNum());
        Debug.Log(val);

        Debug.Log("Spawning Next Tile");
        //spawns the next tile at the connecting position at the right rotation
        Instantiate(tiles[val], this.transform.position + (transform.forward * 4), Quaternion.Euler(0, -90 + this.transform.eulerAngles.y, 0));
        DataHandler.addCoord(this.transform.position + (transform.right * 4));
    }
    //checks the target coordinates to see if they're already occupied
    bool checkCoords()
    {
        for (int count = 0; count <= DataHandler.getCoordPointer();)
        {
            if ((this.transform.position + (transform.right * 4) == DataHandler.getCoord(count)))
            {
                Debug.Log("Tile Detected by tile " + DataHandler.GetTileNum());
                return false;
            }
            count++;
        }
        return true;
    }
}

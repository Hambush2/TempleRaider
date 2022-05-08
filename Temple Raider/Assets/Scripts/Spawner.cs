using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tiles = new GameObject[DataHandler.GetTotalTypesNum()];
    int currentX;
    int currentY;
    public GameObject StartTile;
    Slots currentSlot;
    Slots nextSlot;
    

    void Awake() 
    {
        //StartCoroutine(GridSpawn());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ForwardTileSpawn()
    {
        int val;
        System.Random rand = new System.Random();
        val = rand.Next(0, DataHandler.GetTotalTypesNum());
        Debug.Log(val);


        Instantiate(tiles[val], currentSlot.getTile().transform.position + (transform.right * 4), currentSlot.getTile().transform.rotation);
        
    }

    void RightTileSpawn() 
    {
        int val;
        System.Random rand = new System.Random();
        val = rand.Next(0, DataHandler.GetTotalTypesNum());
        Debug.Log(val);


        Instantiate(tiles[val], currentSlot.getTile().transform.position + (-transform.forward * 4), Quaternion.Euler(0, 90 + currentSlot.getTile().transform.eulerAngles.y, 0));
    }

    void LeftTileSpawn() 
    {
        int val;
        System.Random rand = new System.Random();
        val = rand.Next(0, DataHandler.GetTotalTypesNum());
        Debug.Log(val);


        Instantiate(tiles[val], currentSlot.getTile().transform.position + (-transform.forward * 4), Quaternion.Euler(0, 90 + currentSlot.getTile().transform.eulerAngles.y, 0));
    }

    /*IEnumerator GridSpawn() 
    {
        DataHandler.setSpawnGrid(DataHandler.getGridSize());

        //2d array [row, column] - row number = yVal; column num = xVa

        DataHandler.setSlotXY();

        yield return null;

        bool openRoutes = true;

        currentX = ((DataHandler.getGridSize()) / 2);
        currentY = 0;

        DataHandler.getSpawnCoordVal(currentX, currentY).setTile(StartTile);

        currentSlot = DataHandler.getSpawnCoordVal(currentX, currentY);

        Instantiate(StartTile);

        while (openRoutes)
        {
            //Spawns tiles in valid slots. following one rout
            for (int count = 0; count <= DataHandler.GetMaxTiles();)
            {

                if (currentSlot.ValidSpawns()[0])
                {
                    ForwardTileSpawn();
                    if ((currentY + 1) < DataHandler.getGridSize())
                    {
                        nextSlot = DataHandler.getSpawnCoordVal(currentX, currentY + 1);
                    }
                }
                if (currentSlot.ValidSpawns()[1])
                {
                    RightTileSpawn();
                    if ((currentX + 1) < DataHandler.getGridSize())
                        nextSlot = DataHandler.getSpawnCoordVal(currentX + 1, currentY);
                }
                if (currentSlot.ValidSpawns()[3])
                {
                    LeftTileSpawn();
                    if ((currentX - 1) < 0)
                    {
                        nextSlot = DataHandler.getSpawnCoordVal(currentX - 1, currentY);
                    }
                }

                currentSlot = nextSlot;

                count++;
            }

            //Once the algorithm has finished going down one route, it will check for any other open routes to proporgate
            int rcount;
            bool foundRoute = false;
            for (rcount = 0; rcount < DataHandler.getGridSize();)
            {
                for (int ccount = 0; ccount < DataHandler.getGridSize();)
                {
                    for (int count = 0; count < 4;)
                    {
                        if (DataHandler.getSpawnCoordVal(ccount, rcount).ValidSpawns()[count])
                        {
                            currentSlot = DataHandler.getSpawnCoordVal(ccount, rcount);
                            currentX = ccount;
                            currentY = rcount;
                            foundRoute = true;
                            break;
                        }
                        count++;
                    }
                    if (foundRoute)
                    {
                        break;
                    }
                    ccount++;
                }
                if (foundRoute)
                {
                    break;
                }
                rcount++;
            }
            if (rcount == DataHandler.getGridSize())
            {
                openRoutes = false;
            }
        }
    }*/
}

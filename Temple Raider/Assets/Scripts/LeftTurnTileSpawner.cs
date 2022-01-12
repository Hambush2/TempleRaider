using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTurnTileSpawner : MonoBehaviour
{
    public GameObject[] tiles = new GameObject[DataHandler.GetTotalTypesNum()];
    public GameObject deadEnd;


    void Awake()
    {
        DataHandler.AddTile();

        //RotationAdjustment();

        if (Physics.OverlapSphere(this.transform.position + (transform.forward * 4), 2).Length > 1)
        {
            Debug.Log("Tile Detected by tile " + DataHandler.GetTileNum());
            //this.transform.Translate(Vector3.up * 4);
        }
        else if (DataHandler.GetTileNum() <= DataHandler.GetMaxTiles())
        {
            NextTileSpawn();
        }

        else
        {
            Instantiate(deadEnd, this.transform.position + (transform.forward * 4), Quaternion.Euler(0, -90 + this.transform.eulerAngles.y, 0));

            //Vector3 cPos = newTile.transform.GetChild(0).position;
            //newTile.transform.RotateAround(cPos, cPos, 90);
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

    void NextTileSpawn()
    {
        int val;
        System.Random rand = new System.Random();
        val = rand.Next(0, DataHandler.GetTotalTypesNum());
        Debug.Log(val);


        Instantiate(tiles[val], this.transform.position + (transform.forward * 4), Quaternion.Euler(0, -90 + this.transform.eulerAngles.y, 0));



        //Vector3 cPos = newTile.transform.GetChild(0).position;
        //newTile.transform.RotateAround(cPos, new Vector3(0, 1, 0), transform.rotation.eulerAngles.y + 90);
    }
}

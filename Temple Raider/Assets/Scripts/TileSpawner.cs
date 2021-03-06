using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tiles = new GameObject[DataHandler.GetTotalTypesNum()];
    public GameObject deadEnd;
    public float x, y, z;
    private Vector3 offset;
    void Awake()
    {
        DataHandler.AddTile();

        //RotationAdjustment();
        

        if (Physics.OverlapSphere(this.transform.position + (transform.right * 4), 1).Length > 1)
        {
            Debug.Log("Tile Detected by tile " + DataHandler.GetTileNum());
        }
        else if (DataHandler.GetTileNum() <= 10)
        {
            NextTileSpawn();
        }
        else
        {
            Instantiate(deadEnd, this.transform.position + (transform.right * 4), this.transform.rotation);
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
        val = rand.Next(0,DataHandler.GetTotalTypesNum());
        Debug.Log(val);


        Instantiate(tiles[val], this.transform.position + (transform.right * 4), this.transform.rotation);
    }

    void RotationAdjustment()
    {
        if (transform.rotation.eulerAngles.y == 90)
        {
            offset = -transform.forward * 4;
        }
        if (transform.rotation.eulerAngles.y == -90)
        {
            offset = transform.forward * 4;
        }
        if (transform.rotation.eulerAngles.y == -180 || transform.rotation.eulerAngles.y == 180)
        {
            offset = -transform.right * 4;
        }
        if (transform.rotation.eulerAngles.y == 0)
        {
            offset = transform.right * 4;
        }
    }
}

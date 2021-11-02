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
        offset = new Vector3(x, y, z);

        if (DataHandler.GetTileNum() <= 10)
        {
            NextTileSpawn();
        }
        else
        {
            Instantiate(deadEnd, this.transform.position + offset, Quaternion.identity);
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


        Instantiate(tiles[val], this.transform.position + offset, Quaternion.identity);
    }

    //void RotationAdjustment()
    //{
    //    float temp;

    //    if (transform.rotation.eulerAngles.y == -90)
    //    {
    //        temp = x;
    //        x = z;
    //        z = temp;
    //    }
    //    if (transform.rotation.eulerAngles.y == 90)
    //    {
    //        z = -z;

    //        temp = x;
    //        x = z;
    //        z = temp;
    //    }
    //}
}

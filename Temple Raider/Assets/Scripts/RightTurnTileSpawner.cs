using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTurnTileSpawner : MonoBehaviour
{
    public GameObject[] tiles = new GameObject[DataHandler.GetTotalTypesNum()];
    public GameObject deadEnd;
    public float x, y, z;
    private Vector3 offset;
    public GameObject newTile;
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
            newTile = Instantiate(deadEnd, this.transform.position + offset, Quaternion.Euler(0,90,0));

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


        newTile = Instantiate(tiles[val], this.transform.position + offset, Quaternion.Euler(0,90,0));



        //Vector3 cPos = newTile.transform.GetChild(0).position;
        //newTile.transform.RotateAround(cPos, new Vector3(0, 1, 0), transform.rotation.eulerAngles.y + 90);
    }

    //void RotationAdjustment()
    //{
    //    float temp;

    //    if (transform.rotation.eulerAngles.y == 90)
    //    {
    //        temp = x;
    //        x = z;
    //        z = temp;
    //    }
    //    if (transform.rotation.eulerAngles.y == -90)
    //    {
    //        z = -z;
    //        x = -x;

    //        temp = x;
    //        x = z;
    //        z = temp;
    //    }
    //}
}

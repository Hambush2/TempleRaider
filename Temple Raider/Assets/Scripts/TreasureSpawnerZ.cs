using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawnerZ : MonoBehaviour
{
    public GameObject treasurePile;
    public float minRange = -1.9f;
    public float maxRange = 1.9f;

    // Start is called before the first frame update
    void Start()
    {
        //Does a what is essentially a coin flip to decide if it will spawn or not
        if (Random.Range(0.0f, 1.0f) > 0.5f)
        {
            //If statement is checking the orientation of the assigned tile, so that the treasure spawned will be accessible to the player
            if (this.transform.parent.transform.eulerAngles.y == 0 || this.transform.parent.transform.eulerAngles.y == 180 || this.transform.parent.transform.eulerAngles.y == 180)
            {
                Instantiate(treasurePile, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + Random.Range(minRange, maxRange)), Quaternion.identity, this.transform.parent.transform);
            }
            else if (this.transform.parent.transform.eulerAngles.y == 90 || this.transform.parent.transform.eulerAngles.y == -90)
            {
                Instantiate(treasurePile, new Vector3(this.transform.position.x + Random.Range(minRange, maxRange), this.transform.position.y, this.transform.position.z), Quaternion.identity, this.transform.parent.transform);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

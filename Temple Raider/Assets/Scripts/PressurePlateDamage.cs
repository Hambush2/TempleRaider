using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDamage : MonoBehaviour
{
    //-0.4986, -0.971, 0.4976
    public int damage = 1;
    float startY;
    int wait;
    // Start is called before the first frame update
    void Start()
    {
        startY = this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ticks down the wait variable
        if(wait > 0) 
        {
            wait--;
        }
        //puts the pressure plate back into its starting position
        if ((startY > this.transform.position.y) && (wait <= 0)) 
        {
            this.transform.position = new Vector3(this.transform.position.x, startY, this.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the pressure plate has not been activated then it will deal damage to the player and sink down
        if (wait <= 0)
        {
            other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, this.transform.position.z);
            wait = 60;
        }
    }
}

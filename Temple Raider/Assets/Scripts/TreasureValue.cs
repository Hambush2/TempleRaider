using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureValue : MonoBehaviour
{
    public delegate void UpdateScore(int newScore);
    public static event UpdateScore OnUpdateScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        System.Random rand = new System.Random();
        int val = rand.Next(101, 1000);
        DataHandler.addScore(val);
        other.transform.SendMessage("AddScore", DataHandler.getScore(), SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
    }
}

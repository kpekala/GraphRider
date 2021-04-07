using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is destroying cans when they are far behind the player.
public class CanDestroyer : MonoBehaviour
{  
    private GameObject player;
    private float destroyOffset = 20f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player.transform.position.z > transform.position.z + destroyOffset)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script destroys its road GameObject when road section is far behind player. 
public class RoadDestroyer : MonoBehaviour
{  
 
    private GameObject player;
    private GeneratePath pathManager;
    public GameObject meshHolder;
    private float destroyOffset = 20f;
    void Start()
    {
        player = GameObject.Find("Player");
        pathManager = GetComponent<GeneratePath>();
    }

    void Update()
    {
        if (player.transform.position.z > PathSection.EndZ(pathManager.index) + destroyOffset)
        {
            if (meshHolder != null)
            {
                Destroy(meshHolder);
            }
            Destroy(gameObject);
        }
    }
}

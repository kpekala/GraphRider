using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log(pathManager.EndZ());
    }

    void Update()
    {
        if (player.transform.position.z > pathManager.EndZ() + destroyOffset)
        {
            if (meshHolder != null)
            {
                Destroy(meshHolder);
            }
            Destroy(gameObject);
        }
    }
}

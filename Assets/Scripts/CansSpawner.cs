using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CansSpawner : MonoBehaviour
{
    public GameObject canPrefab;
    private GameObject player;

    private float lastPlayerZPos;
    private float offsetZ = 50;
    private float offsetY = 5;
    void Start()
    {
        player = GameObject.Find("Player");
        lastPlayerZPos = player.transform.position.z;
        SpawnCan();
    }

    void Update()
    {
        if (player.transform.position.z - lastPlayerZPos > 20)
        {
            lastPlayerZPos = player.transform.position.z;
            SpawnCan();
        }
    }

    private void SpawnCan()
    {
        Instantiate(canPrefab, new Vector3(0, offsetY, player.transform.position.z + offsetZ), canPrefab.transform.rotation);
    }
}

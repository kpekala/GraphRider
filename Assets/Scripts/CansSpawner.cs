using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CansSpawner : MonoBehaviour
{
    public GameObject canPrefab;
    private GameObject player;

    private float lastPlayerZPos;
    private float spawnOffsetZ = 50;
    private float spawnPosY = 5;
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
        Instantiate(canPrefab, new Vector3(0, spawnPosY, player.transform.position.z + spawnOffsetZ), canPrefab.transform.rotation);
    }
}

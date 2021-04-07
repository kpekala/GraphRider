using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//This class spawns new road section when necessary
public class RoadSpawner : MonoBehaviour
{

    public GameObject roadPrefab;
    private int nextRoadIndex = 0;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        AddNextRoad();
    }

    private void AddNextRoad()
    {
        GameObject newRoad = Instantiate(roadPrefab, Vector3.zero, roadPrefab.transform.rotation);
        newRoad.GetComponent<GeneratePath>().createRoad(nextRoadIndex);
        nextRoadIndex++;
    }

    void Update(){
        if (player.transform.position.z > EndZPos() - PathSection.pathZLength() / 2)
        {
            AddNextRoad();
        }
    }

    private float EndZPos()
    {
        return nextRoadIndex * PathSection.pathZLength();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
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
        if (player.transform.position.z > EndZPos() - GeneratePath.pathZLength() / 2)
        {
            AddNextRoad();
        }
    }

    private float EndZPos()
    {
        return nextRoadIndex * GeneratePath.pathZLength();
    }
}

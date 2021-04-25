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
    private GameManager _gameManager;

    void Start()
    {
        player = GameObject.Find("Player");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void AddNextRoad()
    {
        GameObject newRoad = Instantiate(roadPrefab, Vector3.zero, roadPrefab.transform.rotation);
        newRoad.GetComponent<GeneratePath>().createRoad(nextRoadIndex);
        nextRoadIndex++;
    }

    void Update(){
        if (player.transform.position.z > EndZPos() - PathSection.pathZLength() / 2 && _gameManager.gameStarted)
        {
            AddNextRoad();
        }
    }

    private float EndZPos()
    {
        return nextRoadIndex * PathSection.pathZLength();
    }

    public void OnGameStart()
    {
        AddNextRoad();
    }
}

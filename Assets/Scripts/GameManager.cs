using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private RoadSpawner _roadSpawner;
    private GameObject _canvas;
    private PlayerController _playerController;

    public TextMeshProUGUI inputGraph;
    public string functionText;

    public bool gameStarted = false;
    void Start()
    {
        _roadSpawner = GameObject.Find("Road Manager").GetComponent<RoadSpawner>();
        _canvas = GameObject.Find("Canvas");
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    public void OnButtonStartClick()
    {
        functionText = inputGraph.text;
        gameStarted = true;
        _canvas.SetActive(false);
        _roadSpawner.OnGameStart();
        _playerController.OnStartGame();
    }
}

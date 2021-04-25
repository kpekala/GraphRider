using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is standard class for controlling player movements and so on
public class PlayerController : MonoBehaviour{  

    public float accelerationSpeed = 5000;
    private Rigidbody playerRb;

    private WheelsManager _wheelsManager;
    private GameManager _gameManager;
 
    void Start(){
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = new Vector3(0, -0.5f, 0);
        _wheelsManager = GameObject.Find("Wheels Manager").GetComponent<WheelsManager>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb.isKinematic = true;
    }

    void FixedUpdate(){
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_wheelsManager.wheelsOnGround() >= 1)
        {
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(verticalInput * accelerationSpeed * transform.forward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuel"))
        {
            Destroy(other.gameObject);
            Debug.Log("Piwo to moje paliwo");
        }
    }

    public void OnStartGame()
    {
        playerRb.isKinematic = false;
    }
}

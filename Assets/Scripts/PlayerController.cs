using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{  

    private float accelerationSpeed = 10000f;
    private Rigidbody playerRb;

    private WheelsManager wheelsManager;
 
    void Start(){
        playerRb = GetComponent<Rigidbody>();
        wheelsManager = GameObject.Find("Wheels Manager").GetComponent<WheelsManager>();
    }

    void Update(){
        MovePlayer();
    }

    private void MovePlayer()
    {
        //Debug.Log(wheelsManager.wheelsOnGround());   
        if (wheelsManager.wheelsOnGround() >= 1)
        {
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(verticalInput * accelerationSpeed * transform.forward);
        }
    }

}

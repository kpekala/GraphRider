using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{  

    public float accelerationSpeed = 5000;
    private Rigidbody playerRb;

    private WheelsManager wheelsManager;
 
    void Start(){
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = new Vector3(0, -0.5f, 0);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuel"))
        {
            Destroy(other.gameObject);
            Debug.Log("Piwo to moje paliwo");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is standard class for controlling player movements and so on
public class PlayerController : MonoBehaviour{  

    public float accelerationSpeed = 5000;
    private Rigidbody playerRb;
    private AudioSource _engineAudio;
    
    private WheelsManager _wheelsManager;
    private GameManager _gameManager;

    public static PlayerController cc;
    public float currentSpeed = 0f;

    void Start()
    {
        cc = this;
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = new Vector3(0, -0.5f, 0);
        _wheelsManager = GameObject.Find("Wheels Manager").GetComponent<WheelsManager>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _engineAudio = GetComponent<AudioSource>();
        playerRb.isKinematic = true;
    }

    void FixedUpdate(){
        MovePlayer();
    }
    void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0,0);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void MovePlayer()
    {
        if (_wheelsManager.wheelsOnGround() >= 1)
        {
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(verticalInput * accelerationSpeed * transform.forward);
            currentSpeed = playerRb.velocity.magnitude;
            //-0.001 * (x^2)
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
        _engineAudio.Play();
    }
}

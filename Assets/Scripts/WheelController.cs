using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class gives information whether wheel is on ground or not
public class WheelController : MonoBehaviour
{

    public bool onGround = false;
    private WheelCollider wheelCollider;
    
    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }

    void Update()
    {
        WheelHit hit;
        onGround = wheelCollider.GetGroundHit(out hit);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            onGround = false;
        }
    }
    
    
}

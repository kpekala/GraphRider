using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WheelsManager : MonoBehaviour{  
 
    public GameObject[] wheels;
    private WheelController[] wheelControllers = new WheelController[4];

    void Start(){
        for(int i=0; i<4; i++)
        {
            wheelControllers[i] = wheels[i].GetComponent<WheelController>();
        }
    }

    void Update(){
        
    }

    public int wheelsOnGround()
    {
        return wheelControllers.Count(wController => wController.onGround);
    }
}

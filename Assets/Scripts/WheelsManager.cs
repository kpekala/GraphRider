using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WheelsManager : MonoBehaviour{  
 
    public WheelController[] wheelControllers;
    void Update(){
        
    }

    public int wheelsOnGround()
    {
        return wheelControllers.Count(wController => wController.onGround);
    }
}

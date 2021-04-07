using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//This class is managing all wheels of car
public class WheelsManager : MonoBehaviour{

    public WheelController[] wheelControllers;
    void Update(){
        
    }

    public int wheelsOnGround()
    {
        return wheelControllers.Count(wController => wController.onGround);
    }
}

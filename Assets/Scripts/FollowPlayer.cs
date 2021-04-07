using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class sets position along player's position with little offset
public class FollowPlayer : MonoBehaviour{

    public GameObject player;
    [SerializeField] Vector3 positionOffset = new Vector3(0, 4, 0);

    void Update(){
        transform.position = player.transform.position + positionOffset;
    }
}

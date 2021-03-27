using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 4, 0);
    void Start(){
        
    }

    void Update(){
        transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z) + offset;
    }
}

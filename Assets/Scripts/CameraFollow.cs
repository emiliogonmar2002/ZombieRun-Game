using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
     player = GameObject.FindWithTag("Player").transform;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Check if the player is still alive
        if(player==null)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if(tempPos.x < maxX && tempPos.x >minX ){
            transform.position = tempPos;
        }      
    }
}

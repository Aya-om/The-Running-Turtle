using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 temposition;
    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyScript.isPlayerAlive==true)
        {
            temposition = transform.position;
            temposition.x = player.position.x;
            transform.position = temposition;
        }
        else
        {
            temposition = transform.position;
        }
        
        

    }
}

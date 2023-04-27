using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCoin : MonoBehaviour
{
    public float xRotate, yRotate, zRotate;
    
    // Update is called once per frame
    void Update()
    {
        RotateCoin();
    }
    void RotateCoin()
    {
        transform.Rotate(xRotate * Time.deltaTime, yRotate * Time.deltaTime, zRotate * Time.deltaTime);
    }
}

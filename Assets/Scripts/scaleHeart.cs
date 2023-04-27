using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleHeart : MonoBehaviour
{
    public float xRotate, yRotate, zRotate;
    

    private void Start()
    {

    }
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

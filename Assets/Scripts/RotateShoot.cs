using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShoot : MonoBehaviour
{
    public float xRotate, yRotate, zRotate,speed;
    private Rigidbody2D rb;
    private string ENEMY_TAG = "Enemy";
    

    

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
       // rb.velocity = transform.right * speed;
        
    }
    // Update is called once per frame
    void Update()
    {
        
        RotateShoots();
    
    }
    void RotateShoots()
    {
        transform.Rotate(xRotate * Time.deltaTime, yRotate * Time.deltaTime, zRotate * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ENEMY_TAG)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
    }
}

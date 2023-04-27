using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGetPlayer : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    public static bool isFire;
    // Start is called before the first frame update
    void Start()
    {
        isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PLAYER_TAG)
        {
            isFire = true;
            Debug.Log(isFire);
            Destroy(gameObject);
        }
    }
}

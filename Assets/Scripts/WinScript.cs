using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private string PLAYER_TAG = "Player";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Level2()
    {
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PLAYER_TAG)
        {
            source.PlayOneShot(clip);
            StartCoroutine(Level2());
        }
    }

}

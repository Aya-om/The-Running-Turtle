using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{
    private string COIN_TAG = "Coin";
    private int coinCounter = 0;
    private string HEART_TAG = "Heart";
    [HideInInspector]
    public static int liveCounter = 0;
    private float volume = 0.3f;

    public Text coinText;
    public Text heartText;
    public AudioSource source;
    public AudioClip clipCoin;
    public AudioClip clipHeart;

    // Start is called before the first frame update
    void Start()
    {
        liveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(COIN_TAG))
        {
            coinCounter++;
            coinText.text = coinCounter.ToString();
            source.PlayOneShot(clipCoin, volume);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag(HEART_TAG))
        {
            liveCounter = 1;
            Debug.Log("heart live "+liveCounter);
            heartText.text =liveCounter.ToString();
            source.PlayOneShot(clipHeart, volume);
            Destroy(collision.gameObject);
        }
    }
}

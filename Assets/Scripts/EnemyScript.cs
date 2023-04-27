using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed;
    private float dirX;
    private bool facingRight = false;
    private Vector3 localeScale;
    private Rigidbody2D rb;

    private string PLAYER_TAG = "Player";
    private string OBSTACLE_TAG = "Obstacle";
    public static bool isPlayerAlive;

    public AudioSource source;
    public AudioClip clipLive;

    //SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        localeScale = transform.localScale;
        isPlayerAlive = true;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        speed = 3;
        //sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveEnemy();
    }
    private void LateUpdate()
    {
        CheckWhereToFace();
    }
    IEnumerator FadeOut()
    {
        Color c = PlayerScript.spr.material.color;
        c.a = 1;
        yield return new WaitForSeconds(0.05f);
        PlayerScript.spr.material.color = c;
    }
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            //Color c = sp.material.color;
            //c.a = f;
            //sp.material.color = c;
            //yield return new WaitForSeconds(0.05f);

            Color c = PlayerScript.spr.material.color;
            c.a = f;
            PlayerScript.spr.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void MoveEnemy()
    {
        rb.velocity = new Vector2(dirX * Random.Range(1, 4), rb.velocity.y);

        //transform.position += new Vector3(-1, 0, 0) * (Random.Range(1,4)) * Time.deltaTime;
    }
    void CheckWhereToFace()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
        {
            facingRight = false;
        }
        if(((facingRight)&& (localeScale.x < 0)) || ((!facingRight) && (localeScale.x > 0)))
        {
            localeScale.x *= -1f;
        }
        transform.localScale = localeScale;
    }
    IEnumerator HidePlayer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            if (CollectCoins.liveCounter == 0)
            {
                isPlayerAlive = false;
                Destroy(collision.gameObject);
                Time.timeScale = 0f;
            }
            else if(CollectCoins.liveCounter == 1)
            {
                isPlayerAlive = true;
                source.PlayOneShot(clipLive);
                StartCoroutine(FadeIn());
                StartCoroutine(HidePlayer());
                StartCoroutine(FadeOut());
                

            }
            //CollectCoins.liveCounter = 0;

        }
        if (collision.gameObject.tag == OBSTACLE_TAG)
        {
            dirX *= -1f;
        }
    }
}

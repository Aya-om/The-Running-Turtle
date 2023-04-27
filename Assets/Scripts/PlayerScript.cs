using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject heart;
    private Animator animator;
    public float speed = 5f;
    public float jumpSpeed = 10f;
    private Rigidbody2D rigidbody;
    public static SpriteRenderer spr;
    private float moveX;

    private string WALK_PARAMETER = "Walk";
    private string JUMP_PARAMETER = "Jump";
    private string OBSTACLE_TAG = "Obstacle";
    private string PLAYER_TAG = "Player";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    public GameObject gameOverWindow;

    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
        AnimatePlayer();
        Jump();
    }
    void MovePlayer()
    {
        moveX = Input.GetAxis("Horizontal");
        Debug.Log(moveX);
        transform.position += new Vector3(moveX, 0f, 0f) * speed * Time.deltaTime;
    }
    int Direction()
    {
        if (moveX < 0f)
        {
            return -1;
        }
        else if(moveX > 0f)
        {
            return +1;
        }
        else
        {
            return 0;
        }
    }
    void AnimatePlayer()
    {
        if (moveX > 0 || moveX < 0)
        {
            animator.SetBool(WALK_PARAMETER, true);
            transform.localScale = new Vector2(transform.localScale.x * Direction(), transform.localScale.y);
        }
        //else if (moveX < 0)
        //{
        //    animator.SetBool(WALK_PARAMETER, true);
        //    transform.localScale = new Vector2(transform.localScale.x * Direction(), transform.localScale.y);
        //    //spr.flipX = true;
        //}
        else
        {
            animator.SetBool(WALK_PARAMETER, false);
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.X) && isGround)
        {
            //rigidbody.velocity =  Vector2.up * jumpSpeed * Time.deltaTime;
            rigidbody.AddForce  (new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
            isGround = false;
            animator.SetBool(JUMP_PARAMETER, true);
        }
        else
        {
            animator.SetBool(JUMP_PARAMETER, false);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(GROUND_TAG) || collision.gameObject.CompareTag(OBSTACLE_TAG))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            if (CollectCoins.liveCounter == 0)
            {
                gameOverWindow.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Destroy(heart);
                //Application.LoadLevel(0);
                CollectCoins.liveCounter = 0;
                
            }
            
        }
        
    }

}

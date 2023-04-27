using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public float shootSpeed;
    public float shootTimer;
    private bool isShooting;
    public GameObject shootFire;
    public Transform shootPosition;

    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isShooting)
        {
            StartCoroutine(Shoot());
            //Debug.Log(FireGetPlayer.isFire);
            
        }
    }
    IEnumerator Shoot()
    {
        int Direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }
        isShooting = true;
        if (FireGetPlayer.isFire)
        {
            GameObject gameObject = Instantiate(shootFire, shootPosition.position, Quaternion.identity);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * Direction() * Time.fixedDeltaTime, 0f);
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * Direction(), gameObject.transform.localScale.y);
            source.PlayOneShot(clip);
            Destroy(gameObject, .5f);
        }
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
    
    
}

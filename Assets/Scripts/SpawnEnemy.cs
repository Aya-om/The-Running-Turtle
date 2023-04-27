using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPos;
    float spawnPosNum;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn_Enemy());
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosNum = Random.Range(0, 2);
            
    }
    IEnumerator Spawn_Enemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject newEnemy = Instantiate(enemy, spawnPos[Random.Range(0, 9)].position, spawnPos[Random.Range(0, 9)].rotation);
            Destroy(newEnemy, 15f);
            
        }
        
    }
}

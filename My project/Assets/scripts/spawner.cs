using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject obj;
    private float randomx;
    Vector2 wheretospawn;
    public float spawnDelay;
    float nextSpawn = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDelay;
            randomx = Random.Range(-4, 4);
            wheretospawn = new Vector2(randomx, transform.position.y);
            GameObject Enemy = Instantiate(obj, wheretospawn, Quaternion.identity);
            Destroy(Enemy, 4f);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SnowflakeSpawner : MonoBehaviour
{

    public GameObject snowflakePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private int frameCount = 0;
    private Random _random = new Random();
    void Update()
    {
        if (frameCount % 20 == 0)
        {
            spawnSnowflake((float)_random.NextDouble() * 32 - 16);
        }
        
        frameCount++;
    }

    public void spawnSnowflake(float x)
    {
        Random random = new Random();
        this.snowflakePrefab.GetComponent<Rigidbody2D>().gravityScale = 1 + (((float)random.NextDouble() - 0.5f) / 2);
        Instantiate(this.snowflakePrefab, new Vector3(x, 9, 0), Quaternion.identity); //y=9 because of aspect ratio
    }
}

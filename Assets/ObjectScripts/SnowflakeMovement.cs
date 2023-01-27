using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SnowflakeMovement : MonoBehaviour
{

    public Rigidbody2D body;

    private int destroyHeight;

    private float size;
    // Start is called before the first frame update
    void Start()
    {
        int[] destroyHeight = { 3, -2, -6, -9 };
        float[] size = { 0.4f, 0.6f, 0.8f, 1f };

        Random random = new Random();
        int ele = random.Next(0, 4);

        this.destroyHeight = destroyHeight[ele];
        this.size = size[ele];

        transform.localScale = new Vector3(transform.localScale.x * this.size, transform.localScale.y * this.size, 1);
    }

    // Update is called once per frame
    private Vector2? prevMouse;
    private int frameDelayCount = 0;
    private static int frameDelay = 10;
    
    void Update()
    {
        if (this.frameDelayCount == SnowflakeMovement.frameDelay)
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vector2Mouse = new Vector2(mouse.x, mouse.y);
            
            if (this.prevMouse == null)
            {
                this.prevMouse = vector2Mouse;
                return;
            }

            Vector2 direction = (Vector2)(this.prevMouse - vector2Mouse);

            direction.y = 0;
            if (direction.x != 0)
            {
                float distance = (vector2Mouse - this.body.position).magnitude;
                float velocity = direction.magnitude * (direction.x / Math.Abs(direction.x)) / (500 * distance * Time.deltaTime);

                if (vector2Mouse.x > this.body.position.x - 20 && vector2Mouse.x < this.body.position.x + 20)
                {
                    Vector2 movement = new Vector2(1, 0) * (-velocity);
                    this.body.velocity += movement;
                }
            }

            this.prevMouse = vector2Mouse;
            this.frameDelayCount = 0;
        }

        if (this.body.position.y < this.destroyHeight)
        {
            Destroy(gameObject);
            return;
        }
        
        this.frameDelayCount++;
    }
}

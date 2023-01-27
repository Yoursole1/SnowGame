using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeMovement : MonoBehaviour
{

    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
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
                float velocity = direction.magnitude * (direction.x / Math.Abs(direction.x)) / (1000 * distance * Time.deltaTime);

                if (vector2Mouse.x > this.body.position.x - 20 && vector2Mouse.x < this.body.position.x + 20)
                {
                    Vector2 movement = new Vector2(1, 0) * (-velocity);
                    this.body.velocity += movement;
                }
            }

            this.prevMouse = vector2Mouse;
            this.frameDelayCount = 0;
        }

        if (this.body.position.y < -9)
        {
            Destroy(gameObject);
            return;
        }
        
        this.frameDelayCount++;
    }
}

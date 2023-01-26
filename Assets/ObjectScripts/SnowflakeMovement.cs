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
            Vector3 mouse = Input.mousePosition;
            Vector2 vector2Mouse = new Vector2(mouse.x, mouse.y);
            if (this.prevMouse == null)
            {
                this.prevMouse = vector2Mouse;
                return;
            }
            
            vector2Mouse.x -= 460; //oh no hardcoded to center mouse
             
            Vector2 direction = (Vector2)(this.prevMouse - vector2Mouse);

            direction.y = 0;
            float velocity = direction.magnitude / (10000 * Time.deltaTime);
            
        Debug.Log(this.body.position.x); //convert mouse to in game world location 
            if (vector2Mouse.x > this.body.position.x - 100 && vector2Mouse.x < this.body.position.x + 100)
            {
                Vector2 movement = new Vector2(1, 0) * (-velocity);
                this.body.velocity += movement;
            }

            
        
            this.prevMouse = vector2Mouse;
            this.frameDelayCount = 0;
        }
        
        
        this.frameDelayCount++;
    }
}

using System;
using System.Collections.Generic;
using GameScripts;
using Unity.VisualScripting;
using UnityEngine;

namespace ObjectScripts
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject player;

        public Rigidbody2D body;
        private Dictionary<KeyCode, bool> pressedKeys = new Dictionary<KeyCode, bool>();

        private static PlayerManager instance;

        public static PlayerManager getInstance() //pseudo singleton
        {
            return instance;
        }


        public void jump()
        {
            this.body.velocity += Vector2.up * 10;
        }

        public void airSideJump(Vector2 dir)
        {
            this.body.velocity += dir;
            
            Debug.Log("air jump (special animation)");
        }

        public void groundSide(Vector2 dir)
        {
            if (this.body.velocity.magnitude > 5)
            {
                return;
            }
            this.body.velocity += dir;
        }
        
        void Start()
        {
            body.position = new Vector2(0, 0);
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            foreach (KeyCombination c in GameData.KeyCombinations)
            {
                c.Function.update(gameObject);
            }
            
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    pressedKeys[code] = true;


                    foreach (KeyCombination combination in GameData.KeyCombinations)
                    {
                        if (combination.isValid(pressedKeys, code, true))
                        {
                            combination.runFunction(true, gameObject);
                        }
                    }

                    continue;
                }

                if (Input.GetKeyUp(code))
                {
                    foreach (KeyCombination combination in GameData.KeyCombinations)
                    {
                        if (combination.isValid(pressedKeys, code, false))
                        {
                            combination.runFunction(false, gameObject);
                        }
                    }

                    pressedKeys[code] = false;
                }
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {


            Vector3 c = collision.contacts[0].normal;
            Debug.Log(c);
            float angle = Vector3.Angle(c, Vector3.up);

            if (Mathf.Approximately(angle, 0))
            {
                GameData.playerIsOnGround = true;
            }

            if (Mathf.Approximately(angle, 180))
            {
                Debug.Log("Up");
            }

            if (Mathf.Approximately(angle, 90))
            {
                Vector3 cross = Vector3.Cross(Vector3.forward, c);
                if (cross.y > 0)
                {
                    Debug.Log("Left");
                }
                else
                {
                    Debug.Log("Right");
                }
            }
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            GameData.playerIsOnGround = false;
        }
    }
}
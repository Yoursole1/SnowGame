using System;
using System.Collections.Generic;
using GameScripts;
using UnityEngine;

namespace ObjectScripts
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject player;

        public Rigidbody2D body;
        private Dictionary<KeyCode, bool> pressedKeys = new Dictionary<KeyCode, bool>();

        void Start()
        {
            body.position = new Vector2(0, 0);
        }

        // Update is called once per frame
        void Update()
        {

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
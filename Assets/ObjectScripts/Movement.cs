using System.Collections.Generic;
using UnityEngine;
using System;
using GameScripts;

public class Movement : MonoBehaviour
{

    public Rigidbody2D body;
    private Dictionary<KeyCode, bool> pressedKeys;

    void Start()
    {
        this.body.position = new Vector2(0, 0);
        this.pressedKeys = new Dictionary<KeyCode, bool>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(code))
            {
                this.pressedKeys[code] = true;
                
                
                foreach (KeyCombination combination in GameData.KeyCombinations)
                {
                    if (combination.isValid(this.pressedKeys, code, true))
                    {
                        combination.runFunction(true);
                    }
                }
                
                continue;
            }

            if (Input.GetKeyUp(code))
            {
                foreach (KeyCombination combination in GameData.KeyCombinations)
                {
                    if (combination.isValid(this.pressedKeys, code, false))
                    {
                        combination.runFunction(false);
                    }
                }
                
                this.pressedKeys[code] = false;
            }
        }
    }
}

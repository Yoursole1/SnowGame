using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GameScripts
{
    public class KeyCombination : ValueAttribute
    {
        private KeyCode[] _code; //last key pressed is the "trigger key"
        private KeyFunction _function;
        private bool active;

        public KeyCombination(KeyFunction function, KeyCode[] code)
        {
            this._code = code;
            this._function = function;
        }

        //called when a key is pressed.
        public bool isValid(Dictionary<KeyCode, bool> pressedKeys, KeyCode latestPress, bool keyDown)
        {
            if (keyDown)
            {
                if (latestPress != this._code[this._code.Length - 1])
                {
                    return false;
                }
            
                for (int i = 0; i < _code.Length - 1; i++) //we already know the last element is pressed, so ignore it
                {
                    KeyCode toCheck = this._code[i];
                    if (!pressedKeys.ContainsKey(toCheck) || !pressedKeys[toCheck])
                    {
                        return false;
                    }
                }

                return true;
            }

            return latestPress == this._code[this._code.Length - 1];
        }

        public void runFunction(bool keyDown, GameObject player)
        {
            if (!this.active && keyDown)
            {
                this._function.triggerKeyDown(player);
                this.active = true;
                return;
            }

            if (!this.active)
            {
                return;
            }
            this.active = false;
            this._function.triggerKeyUp(player);
        }
    }
}

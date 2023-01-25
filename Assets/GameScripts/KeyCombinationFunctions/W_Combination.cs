using UnityEngine;

namespace GameScripts
{
    public class W_Combination : KeyFunction
    {
        public void triggerKeyDown()
        {
            Debug.Log("w pressed");
        }

        public void triggerKeyUp()
        {
            Debug.Log("w lifted");
        }
    }
}
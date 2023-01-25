using UnityEngine;

namespace GameScripts
{
    public class WR_Combination : KeyFunction
    {
        public void triggerKeyDown()
        {
            Debug.Log("WR Active");
        }

        public void triggerKeyUp()
        {
            Debug.Log("WR DeActive");
        }
    }
}
using UnityEngine;

namespace GameScripts
{
    public class WR_Combination : KeyFunction
    {
        public void triggerKeyDown(GameObject player)
        {
            Debug.Log("WR Active");
        }

        public void triggerKeyUp(GameObject player)
        {
            Debug.Log("WR DeActive");
        }
    }
}
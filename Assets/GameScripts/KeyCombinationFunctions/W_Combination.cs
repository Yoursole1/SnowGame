using UnityEngine;

namespace GameScripts
{
    public class W_Combination : KeyFunction
    {
        public void triggerKeyDown(GameObject player)
        {
            player.GetComponent<Rigidbody2D>().velocity += Vector2.up * 10;
        }

        public void triggerKeyUp(GameObject player)
        {
            Debug.Log("w lifted");
        }
    }
}
using ObjectScripts;
using UnityEngine;

namespace GameScripts.KeyCombinationFunctions
{
    public class A_Combination : KeyFunction
    {
        public void triggerKeyDown(GameObject player)
        {
            if (GameData.playerIsOnGround)
            {
                PlayerManager.getInstance().groundSide(Vector2.left * new Vector2(10, 10));
            }
        }

        public void triggerKeyUp(GameObject player)
        {
            
        }
    }
}
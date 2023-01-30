using ObjectScripts;
using UnityEngine;

namespace GameScripts.KeyCombinationFunctions
{
    public class Space_Combination : KeyFunction
    {
        public void triggerKeyDown(GameObject player)
        {
            if (GameData.playerIsOnGround)
            {
                PlayerManager.getInstance().jump();
            }
        }

        public void triggerKeyUp(GameObject player)
        {
            
        }

        public void update(GameObject player)
        {
            
        }
    }
}
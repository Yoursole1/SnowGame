using ObjectScripts;
using UnityEngine;

namespace GameScripts.KeyCombinationFunctions
{
    public class D_Combination : KeyFunction
    {
        private bool active;
        public void triggerKeyDown(GameObject player)
        {
            this.active = true;
        }

        public void triggerKeyUp(GameObject player)
        {
            this.active = false;
        }

        public void update(GameObject player)
        {
            if (this.active)
            {
                PlayerManager.getInstance().groundSide(Vector2.right);
            }
        }
    }
}
using UnityEngine;

namespace GameScripts.KeyCombinationFunctions
{
    public interface KeyFunction
    {
        void triggerKeyDown(GameObject player);
        void triggerKeyUp(GameObject player);

        void update(GameObject player); // called on loop and run iff the combination is active
    }
}
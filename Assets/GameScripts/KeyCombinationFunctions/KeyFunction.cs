using UnityEngine;

namespace GameScripts.KeyCombinationFunctions
{
    public interface KeyFunction
    {
        void triggerKeyDown(GameObject player);
        void triggerKeyUp(GameObject player);
    }
}
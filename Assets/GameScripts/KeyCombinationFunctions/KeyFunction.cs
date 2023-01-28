using UnityEngine;

namespace GameScripts
{
    public interface KeyFunction
    {
        void triggerKeyDown(GameObject player);
        void triggerKeyUp(GameObject player);
    }
}
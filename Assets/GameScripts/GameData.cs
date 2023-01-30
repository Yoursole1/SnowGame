using System.Collections.Generic;
using UnityEngine;

namespace GameScripts
{
    public class GameData
    {
        public static bool playerIsOnGround;
        
        public static List<KeyCombination> KeyCombinations = new List<KeyCombination>
        {
            new (new W_Combination(), new [] { KeyCode.W}),
            
            new(new WR_Combination(), new [] { KeyCode.W, KeyCode.R}),
            
            new(new Space_Combination(), new [] { KeyCode.Space})
        };


    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Gate
{
    public class ScoreSystem : MonoBehaviour
    {
        public static ScoreSystem instance;
        private List<PlayerScore> _scores;

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }
        
        
    }
}
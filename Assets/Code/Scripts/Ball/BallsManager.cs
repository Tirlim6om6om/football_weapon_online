using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Ball
{
    public class BallsManager : MonoBehaviour
    {
        public static BallsManager instance;

        [SerializeField] private int maxBalls = 30;
        
        [SerializeField] private List<Ball> balls;

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

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
            if (balls.Count > maxBalls)
            {
                balls[0].Destroy();
                balls.Remove(balls[0]);
                //balls.Remove(balls[0]);
            }
        }
    }
}

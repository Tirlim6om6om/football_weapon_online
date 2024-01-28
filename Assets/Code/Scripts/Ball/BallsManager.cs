using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Ball
{
    public class BallsManager : MonoBehaviour
    {
        public static BallsManager instance;

        [SerializeField] private int maxBalls = 15;
        
        [SerializeField] private List<Shell> balls;

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

        public void AddBall(Shell ball)
        {
            balls.Add(ball);
            if (balls.Count > maxBalls)
            {
                PhotonNetwork.Destroy(balls[0].gameObject);
                balls.Remove(balls[0]);
            }
        }
    }
}

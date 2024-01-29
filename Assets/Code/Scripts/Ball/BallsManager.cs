using System;
using System.Collections;
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

        private PhotonView _view;

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

            TryGetComponent(out _view);
        }

        public void AddBall(Shell ball)
        {
            balls.Add(ball);
            if (balls.Count > maxBalls)
            {
                StartCoroutine(DeleteFirst());
            }
        }

        private IEnumerator DeleteFirst()
        {
            //PhotonNetwork.Destroy(balls[0].gameObject);
            Destroy(balls[0].gameObject);
            yield return new WaitWhile(() => balls[0].gameObject == null);
            balls.Remove(balls[0]);
        }
    }
}

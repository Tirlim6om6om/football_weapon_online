using System;
using UnityEngine;

namespace Code.Scripts.Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : Shell
    {
        [SerializeField] private float multiplyForce;
        private Rigidbody _rb;

        private void Awake()
        {
            TryGetComponent(out _rb);
        }

        private void Start()
        {
            BallsManager.instance.AddBall(this);
        }

        public override void SetPhysics(bool active)
        {
            _rb.isKinematic = !active;
        }

        public override void Kick(Vector3 axis)
        {
            _rb.AddForce(axis * multiplyForce);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
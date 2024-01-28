using System;
using System.Collections;
using Photon.Pun;
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

        public override void SetPhysics(bool active)
        {
            _rb.isKinematic = !active;
        }

        public override void Kick(Vector3 axis)
        {
            _rb.AddForce(axis * multiplyForce);
        }
    }
}
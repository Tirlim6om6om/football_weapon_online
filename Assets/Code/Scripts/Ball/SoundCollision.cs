using UnityEngine;

namespace Code.Scripts.Ball
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class SoundCollision : MonoBehaviour
    {
        private Rigidbody _rb;
        private AudioSource _source;
        
        private void Start()
        {
            TryGetComponent(out _rb);
            TryGetComponent(out _source);
        }

        private void OnCollisionEnter(Collision collision)
        {
            print("play");
            _source.volume = _rb.velocity.magnitude / 100;
            _source.Play();
        }
    }
}

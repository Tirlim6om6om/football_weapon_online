using Code.Scripts.Ball;
using UnityEngine;

namespace Code.Scripts.Player
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private Transform point;
        
        private Shell _shell;

        public bool Shoot(float forceInput)
        {
            if(!_shell)
                return false;
            _shell.transform.parent = null;
            _shell.SetPhysics(true);
            _shell.Kick(point.forward * force * forceInput);
            BallsManager.instance.AddBall(_shell);
            _shell = null;
            return true;
        }

        public void SetLoad(GameObject obj)
        {
            obj.TryGetComponent(out _shell);
        }

        public bool HasShell() => _shell;
    }
}

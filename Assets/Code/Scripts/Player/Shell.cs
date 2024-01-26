using UnityEngine;

namespace Code.Scripts.Player
{
    public abstract class Shell : MonoBehaviour
    {
        public abstract void SetPhysics(bool active);
        public abstract void Kick(Vector3 axis);
    }
}
using UnityEngine;

namespace Code.Scripts.Ball
{
    public abstract class Shell : MonoBehaviour
    {
        public int id;
        public abstract void SetPhysics(bool active);
        public abstract void Kick(Vector3 axis);
    }
}
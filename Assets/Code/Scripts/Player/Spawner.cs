using UnityEngine;

namespace Code.Scripts.Player
{
    public abstract class Spawner : MonoBehaviour
    {
        public abstract GameObject Spawn(GameObject prefab, Transform pos);
    }
}
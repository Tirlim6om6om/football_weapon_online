using UnityEngine;

namespace Code.Scripts.Player
{
    public class SpawnerOffline : Spawner
    {
        public override GameObject Spawn(GameObject prefab, Transform pos)
        {
            return Instantiate(prefab, pos.position, pos.rotation);
        }
    }
}
using Code.Scripts.Player;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class SpawnerOnline : Spawner
    {
        public override GameObject Spawn(GameObject prefab, Transform pos)
        {
            return PhotonNetwork.Instantiate(prefab.name, pos.position, pos.rotation);
        }
    }
}
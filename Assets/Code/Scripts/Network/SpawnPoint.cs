using UnityEngine;

namespace Code.Scripts.Network
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform playerPoint;
        [SerializeField] private Transform gatePoint;
        [SerializeField] private Transform scorePoint;

        public Transform GetPlayerPoint => playerPoint;
        public Transform GetGatePoint => gatePoint;
        public Transform GetScorePoint => scorePoint;
    }
}
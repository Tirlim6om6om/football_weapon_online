using Code.Scripts.Gate;
using Code.Scripts.Player;
using UnityEngine;

public class GateCollider : MonoBehaviour
{
    [SerializeField] private PlayerScore player;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Shell shell))
        {
            player.ChangePoints(shell.id);
        }
    }
}

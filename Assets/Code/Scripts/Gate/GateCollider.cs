using Code.Scripts.Ball;
using Code.Scripts.Data;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Gate
{
    public class GateCollider : MonoBehaviour
    {
        [SerializeField] private PhotonView view;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Shell shell))
            {
                PlayerInfo playerInfoGate = PlayerDB.instance.GetPlayer(view.Owner.UserId);
                shell.TryGetComponent(out PhotonView shellView);
                PlayerInfo playerInfoShell = PlayerDB.instance.GetPlayer(shellView.Owner.UserId);
                playerInfoGate.score.Minus();
                print(playerInfoGate.nickname);
                if(playerInfoGate != playerInfoShell)
                    playerInfoShell.score.Plus();
            }
        }
    }
}

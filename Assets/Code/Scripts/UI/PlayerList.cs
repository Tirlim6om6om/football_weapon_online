using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.UI
{
    public class PlayerList : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform parent;
        
        private List<PlayerInfo> players = new List<PlayerInfo>();
        
        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            GameObject newPanel = PhotonNetwork.Instantiate("PlayerElement");//TODO доработать
            newPanel.transform.parent = parent;
            PlayerInfo newPlayerInfo = new PlayerInfo(newPlayer.NickName, newPlayer.UserId, players.Count, newPanel);
            players.Add(newPlayerInfo);
            newPanel.TryGetComponent(out PlayerElement playerElement);
            playerElement.SetInfo(newPlayerInfo);
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            players.Remove(GetPlayer(otherPlayer.UserId));
        }

        private PlayerInfo GetPlayer(string userId)
        {
            foreach (var player in players)
            {
                if (player.id == userId)
                {
                    return player;
                }
            }
            return null;
        }
    }
}

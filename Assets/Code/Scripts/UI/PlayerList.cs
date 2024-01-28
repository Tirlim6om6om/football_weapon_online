using System;
using System.Collections.Generic;
using Code.Scripts.Data;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.UI
{
    public class PlayerList : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform parent;

        private void Start()
        {
            UpdateList();
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
           UpdateList();
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
            PlayerDB.instance.Clear();

            foreach (var player in players)
            {
                //GameObject newPanel = PhotonNetwork.Instantiate(prefab.name, parent.position, Quaternion.identity);
                GameObject newPanel = Instantiate(prefab, parent);
                newPanel.transform.parent = parent;
                PlayerInfo newPlayerInfo = new PlayerInfo(player.NickName, 
                    player.UserId, PlayerDB.instance.GetFirstIdColor(), newPanel);
                PlayerDB.instance.AddPlayer(newPlayerInfo);
                newPanel.TryGetComponent(out PlayerElement playerElement);
                playerElement.SetInfo(newPlayerInfo);
            }
        }
    }
}

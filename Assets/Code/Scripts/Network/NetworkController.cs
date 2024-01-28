using System;
using System.Collections.Generic;
using Code.Scripts.Data;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject gate;
        [SerializeField] private GameObject scoreboard;
        [SerializeField] private List<SpawnPoint> spawns;

        private void Start()
        {
            PlayerNetworkObj playerNetworkObj = new PlayerNetworkObj();
            int idColor = PlayerDB.instance.GetPlayer(PhotonNetwork.LocalPlayer.UserId).idColor;
            Transform playerPos = spawns[idColor].GetPlayerPoint;
            Transform gatePos = spawns[idColor].GetGatePoint;
            Transform scorePos = spawns[idColor].GetScorePoint;
            playerNetworkObj.player = PhotonNetwork.Instantiate(player.name, playerPos.position, playerPos.rotation);
            playerNetworkObj.gate = PhotonNetwork.Instantiate(gate.name, gatePos.position, gatePos.rotation);
            playerNetworkObj.scoreboard = PhotonNetwork.Instantiate(scoreboard.name, scorePos.position, scorePos.rotation);
        }
    }
}

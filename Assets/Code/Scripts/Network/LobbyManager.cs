using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts.Network
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        private string _playerName = "Player 1";
        private string _gameVersion = "0.9";
        
        private void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = _gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        
        public override void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster");
            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }
        
        public void CreateRoom(string roomName)
        {
            PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 4 });
        }

        public override void OnJoinedRoom()
        {
            print("Connect to: " + PhotonNetwork.CurrentRoom.Name);
            PhotonNetwork.LoadLevel("Lobby");
        }
    }
}

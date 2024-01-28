using System;
using System.Collections.Generic;
using Code.Scripts.Network;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Code.Scripts.UI
{
    public class RoomList : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> rooms = new List<GameObject>();


        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            foreach (var room in rooms)
            {
                Destroy(room);
            }
            rooms = new List<GameObject>();
            
            foreach (var roomInfo in roomList)
            {
                GameObject newRoom = Instantiate(prefab, parent);
                newRoom.TryGetComponent(out RoomElement roomElement);
                roomElement.SetInfo(roomInfo);
                rooms.Add(newRoom);
            }
        }
    }
}

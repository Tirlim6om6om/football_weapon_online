﻿using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Data
{
    public class PlayerDB : MonoBehaviour
    {
        public static PlayerDB instance;
        private List<PlayerInfo> _playersInfo = new List<PlayerInfo>();
        
        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(transform.root.gameObject);
            }
        }

        public void AddPlayer(PlayerInfo playerInfo)
        {
            if (GetPlayer(playerInfo.id) == null)
            {
                _playersInfo.Add(playerInfo);
            }
        }

        public PlayerInfo GetPlayer(string id)
        {
            foreach (var playerInfo in _playersInfo)
            {
                if (playerInfo.id == id)
                {
                    return playerInfo;
                }
            }
            return null;
        }

        public void Clear()
        {
            foreach (var playerInfo in _playersInfo)
            {
                Destroy(playerInfo.panel);
            }
            
            _playersInfo = new List<PlayerInfo>();
        }
        
        public void Remove(PlayerInfo playerInfo)
        {
            Destroy(playerInfo.panel);
            _playersInfo.Remove(playerInfo);
        }

        public void Remove(string id)
        {
            Remove(GetPlayer(id));
        }
        
        public int GetFirstIdColor(int start = 0)
        {
            for (int i = start; i < 4; i++)
            {
                bool has = false;
                foreach (var playerInfo in _playersInfo)
                {
                    if (playerInfo.idColor == i)
                        has = true;
                }
                if (!has)
                {
                    return i;
                }
            }
            return 0;
        }

        public void AddColor(string id, int add)
        {
            if (TryGetComponent(out PhotonView view))
            {
                view.RPC(nameof(ChangeColor), RpcTarget.All, id, add);
            }
        }
    
        [PunRPC]
        private void ChangeColor(string id, int add)
        {
            PlayerInfo playerInfo = GetPlayer(id);
            int newId = playerInfo.idColor + add;
            if (newId == 4)
                newId = 0;
            if (newId == -1)
                newId = 3;
            playerInfo.SetColor(GetFirstIdColor(newId));
        }
    }
}
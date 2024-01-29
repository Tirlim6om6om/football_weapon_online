using System;
using Code.Scripts.Data;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class PlayerScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nick;
        [SerializeField] private TextMeshProUGUI score;
        
        private void Start()
        {
            TryGetComponent(out PhotonView view);
            PlayerInfo playerInfo = PlayerDB.instance.GetPlayer(view.Owner.UserId);
            nick.text = playerInfo.nickname;
            playerInfo.score.changeScoreEvent.AddListener(UpdateInfo);
        }

        private void UpdateInfo(int value)
        {
            score.text = value.ToString();
        }
    }
}

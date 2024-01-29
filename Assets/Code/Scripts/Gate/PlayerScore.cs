using System;
using Code.Scripts.Data;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts.Gate
{
    public class PlayerScore : MonoBehaviour
    {
        public int id;
        public UnityEvent<int> changeScoreEvent;
        [SerializeField] private TextMeshProUGUI textScore;
        private PhotonView _view;
        private int _score;

        private void Start()
        {
            TryGetComponent(out _view);
            PlayerDB.instance.GetPlayer(_view.Owner.UserId).score = this;
        }
        
        public void Plus()
        {
            _view.RPC(nameof(UpdateScore), RpcTarget.All, 1);
        }
        
        public void Minus()
        {
            if(_score == 0)
                return;
            _view.RPC(nameof(UpdateScore), RpcTarget.All, -1);
        }

        [PunRPC]
        public void UpdateScore(int add)
        {
            _score += add;
            changeScoreEvent.Invoke(_score);
            UpdateText();
        }

        public void UpdateText()
        {
            if(textScore == null)
                return;
            textScore.text = _score.ToString();
        }

    }
}

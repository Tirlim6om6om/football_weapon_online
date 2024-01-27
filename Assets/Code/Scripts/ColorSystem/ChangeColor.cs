using System;
using System.Collections;
using Code.Scripts.Data;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.ColorSystem
{
    public class ChangeColor : MonoBehaviour
    {
        [SerializeField] private GetColorPlayer colorPlayer;
        
        private void Start()
        {
            StartCoroutine(WaitInitialization());
        }

        private IEnumerator WaitInitialization()
        {
            yield return new WaitWhile(() => PlayerDB.instance.GetPlayer(PhotonNetwork.LocalPlayer.UserId) == null);
            colorPlayer.SetId(PhotonNetwork.LocalPlayer.UserId);
        }

        public void Plus()
        {
            PlayerDB.instance.AddColor(PhotonNetwork.LocalPlayer.UserId, 1);
        }

        public void Minus()
        {
            PlayerDB.instance.AddColor(PhotonNetwork.LocalPlayer.UserId, -1);
        }
    }
}
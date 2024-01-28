using System;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class OnlyHost : MonoBehaviour
    {
        private void OnEnable()
        {
            if(!PhotonNetwork.IsMasterClient)
                gameObject.SetActive(false);
        }
    }
}

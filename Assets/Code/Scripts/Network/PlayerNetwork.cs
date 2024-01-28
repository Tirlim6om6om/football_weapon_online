using System;
using Code.Scripts.Player;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class PlayerNetwork : MonoBehaviour
    {
        [SerializeField] private GameObject cam;
        [SerializeField] private GameObject canvas;
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private Shooter shooter;
        [SerializeField] private Reloader reloader;

        private void Start()
        {
            TryGetComponent(out PhotonView view);
            if(view.IsMine)
                return;
            TryGetComponent(out PlayerController playerController);
            Destroy(playerController);
            if (cam.TryGetComponent(out Camera camComponent))
            {
                Destroy(camComponent);
            }
            if (cam.TryGetComponent(out AudioListener audioListener))
            {
                Destroy(audioListener);
            }
            Destroy(canvas);
            Destroy(weaponController);
            Destroy(shooter);
            Destroy(reloader);
        }
    }
}
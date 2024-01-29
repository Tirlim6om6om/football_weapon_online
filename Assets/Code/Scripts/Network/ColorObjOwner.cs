using System;
using Code.Scripts.ColorSystem;
using Code.Scripts.Data;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Scripts.Network
{
    public class ColorObjOwner : MonoBehaviour
    {
        [SerializeField] private PhotonView view;
        private Color _color;

        private void Start()
        {
            TryGetComponent(out IColorSetter colorSetter);
            PlayerInfo playerInfo = PlayerDB.instance.GetPlayer(view.Owner.UserId);
            colorSetter.SetColor(ColorManager.instance.GetColor(playerInfo.idColor));
        }
    }
}

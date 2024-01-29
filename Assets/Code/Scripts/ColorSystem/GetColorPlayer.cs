using System;
using Code.Scripts.Data;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.ColorSystem
{
    public class GetColorPlayer : MonoBehaviour
    {
        private Color _color;
        private string id;
        
        public void SetId(string idPlayer)
        {
            id = idPlayer;
            print(gameObject.name + " : " + PlayerDB.instance.GetPlayer(id).nickname);
            PlayerDB.instance.GetPlayer(id).ColorChange += UpdateColor;
            UpdateColor(PlayerDB.instance.GetPlayer(id).idColor);
        }

        private void UpdateColor(int idColor)
        {
            _color = ColorManager.instance.GetColor(idColor);
            if (TryGetComponent(out IColorSetter setter))
            {
                setter.SetColor(_color);
            }
        }
    }
}
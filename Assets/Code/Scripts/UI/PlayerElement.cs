using Code.Scripts.ColorSystem;
using Code.Scripts.Data;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.UI
{
    public class PlayerElement : MonoBehaviour
    {
        [SerializeField] private GetColorPlayer coloring;
        [SerializeField] private TextMeshProUGUI nickname;

        public void SetInfo(PlayerInfo playerInfo)
        {
            coloring.SetId(playerInfo.id);
            nickname.text = playerInfo.nickname;
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.UI
{
    public class PlayerElement : MonoBehaviour
    {
        [SerializeField] private Image imageColor;
        [SerializeField] private TextMeshProUGUI nickname;

        public void SetInfo(PlayerInfo playerInfo)
        {
            //imageColor.color = color; TODO ДОДЕЛАТЬ ЦВЕТ ПО ID
            nickname.text = playerInfo.id;
        }
    }
}

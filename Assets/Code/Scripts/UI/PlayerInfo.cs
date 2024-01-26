using UnityEngine;

namespace Code.Scripts.UI
{
    public class PlayerInfo
    {
        public string nickname;
        public string id;
        public int idColor;
        public GameObject panel;

        public PlayerInfo(string nickname, string id, int idColor, GameObject panel)
        {
            this.nickname = nickname;
            this.id = id;
            this.idColor = idColor;
            this.panel = panel;
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts.Data
{
    public class PlayerInfo
    {
        public string nickname;
        public string id;
        public int idColor;
        public GameObject panel;
        public delegate void OnChange(int value);
        public event OnChange ColorChange;

        public PlayerInfo(string nickname, string id, int idColor, GameObject panel)
        {
            this.nickname = nickname;
            this.id = id;
            this.idColor = idColor;
            this.panel = panel;
        }

        public void SetColor(int newId)
        {
            idColor = newId;
            ColorChange?.Invoke(idColor);
        }
    }
}
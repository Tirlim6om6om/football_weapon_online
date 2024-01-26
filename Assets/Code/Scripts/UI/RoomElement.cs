using TMPro;
using UnityEngine;

namespace Code.Scripts.UI
{
    public class RoomElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI countPlayerText;

        public void SetInfo(string nameServer, string count)
        {
            nameText.text = nameServer;
            countPlayerText.text = count;
        }

        public void Connect()
        {
            
        }
    }
}

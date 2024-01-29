using UnityEngine;

namespace Code.Scripts.Player
{
    public class HideCursor : MonoBehaviour
    {
        private void OnEnable()
        {
            SetVisible(false);
        }

        private void OnDisable()
        {
            SetVisible(true);
        }

        public void SetVisible(bool active)
        {
            Cursor.visible = active;
            Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}

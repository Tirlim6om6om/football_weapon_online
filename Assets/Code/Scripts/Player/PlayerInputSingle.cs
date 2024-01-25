using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts.Player
{
    public class PlayerInputSingle : MonoBehaviour
    {
        public static MainInput Input;

        private void Awake()
        {
            Input = new MainInput();
        }

        private void OnEnable()
        {
            Input.Enable();
        }

        private void OnDisable()
        {
            Input.Disable();
        }
    }
}
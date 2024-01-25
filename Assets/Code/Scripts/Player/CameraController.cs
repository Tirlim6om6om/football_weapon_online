using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float sensivity = 1;
        [SerializeField] private float minimumVert = -45.0f;
        [SerializeField] private float maximumVert = 45.0f;
        private float _rotationX = 0;
        
        private void Start()
        {
            PlayerInputSingle.Input.Player.CameraMove.performed += Move;
        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            _rotationX = Mathf.Clamp(
                _rotationX - value.y * sensivity, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y + value.x * sensivity;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}

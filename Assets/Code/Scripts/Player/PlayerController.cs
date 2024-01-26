using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private WeaponController weapon;
        [SerializeField] private CameraController cameraController;
        
        private MainInput _input;

        private void OnEnable()
        {
            _input = new MainInput();
            _input.Enable();
            _input.Player.Shoot.started += weapon.Shoot;
            _input.Player.Shoot.canceled += weapon.Shoot;
            _input.Player.CameraMove.performed += cameraController.Move;
        }

        private void OnDisable()
        {
            _input.Player.Shoot.started -= weapon.Shoot;
            _input.Player.Shoot.canceled -= weapon.Shoot;
            _input.Player.CameraMove.performed -= cameraController.Move;
            _input.Disable();
        }
    }
}

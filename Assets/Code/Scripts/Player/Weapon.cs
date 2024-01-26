using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts.Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private Transform point;
        [SerializeField] private Reloader reloader;
        
        private Shell _shell;
        
        private void OnEnable()
        {
            reloader.reloaded.AddListener(GetReload);
        }

        private void OnDisable()
        {
            reloader.reloaded.RemoveListener(GetReload);
        }

        public void Shoot(InputAction.CallbackContext context)
        {
            if(!_shell)
                return;
            _shell.transform.parent = null;
            _shell.SetPhysics(true);
            _shell.Kick(point.forward * force);
            _shell = null;
            reloader.Reload();
        }

        private void GetReload(GameObject obj)
        {
            obj.TryGetComponent(out _shell);
        }
    }
}

using System.Collections;
using Code.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Shooter shooter;
        [SerializeField] private Reloader reloader;
        [SerializeField] private BarUI bar;
        [SerializeField] private float speedForce = 0.02f;
        
        private bool _press;
        private float _force;

        private void OnEnable()
        {
            reloader.reloaded.AddListener(shooter.SetLoad);
        }

        private void OnDisable()
        {
            reloader.reloaded.RemoveListener(shooter.SetLoad);
        }
        
        public void Shoot(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() == 0)
            {
                if (shooter.Shoot(_force))
                {
                    reloader.Reload();
                }
                _press = false;
                _force = 0;
                bar.SetValue(0);
            }
            else
            {
                _press = true;
                StartCoroutine(GetForce());
            }
        }
        
        private IEnumerator GetForce()
        {
            while (_press && _force < 1)
            {
                _force += speedForce;
                bar.SetValue(_force);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}

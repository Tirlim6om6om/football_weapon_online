using System.Collections;
using Code.Scripts.Ball;
using Code.Scripts.Gate;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts.Player
{
    public class Reloader : MonoBehaviour
    {
        public UnityEvent<GameObject> reloaded;
        
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform point;
        [SerializeField] private float timeReload = 1;
        [SerializeField] private PlayerScore score;

        private Spawner _spawner;
        
        private void Start()
        {
            TryGetComponent(out _spawner);
            Reload();
        }

        public void Reload()
        {
            StartCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            yield return new WaitForSeconds(timeReload);
            GameObject newObj = _spawner.Spawn(prefab, point);
            newObj.transform.parent = point;
            newObj.transform.localPosition = Vector3.zero;
            if (newObj.TryGetComponent(out Shell shell))
            {
                shell.SetPhysics(false);
            }
            shell.id = score.id;
            newObj.transform.localPosition = Vector3.zero;
            reloaded.Invoke(newObj);
        }
    }
}

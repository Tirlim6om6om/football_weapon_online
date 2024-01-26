using System.Collections;
using Code.Scripts.Ball;
using Code.Scripts.Gate;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts.Player
{
    public class Reloader : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform point;
        [SerializeField] private float timeReload = 1;
        [SerializeField] private PlayerScore score;

        public UnityEvent<GameObject> reloaded;

        private void Start()
        {
            Reload();
        }

        public void Reload()
        {
            StartCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            yield return new WaitForSeconds(timeReload);
            GameObject newObj = Instantiate(prefab, point.position, point.rotation, point);
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

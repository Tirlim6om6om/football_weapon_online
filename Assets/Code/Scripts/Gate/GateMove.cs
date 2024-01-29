using UnityEngine;

namespace Code.Scripts.Gate
{
    public class GateMove : MonoBehaviour
    {
        [SerializeField] private Transform gate;
        [SerializeField] private float distanceLeft;
        [SerializeField] private float distanceRight;
        [SerializeField] private float speed;

        private bool _right;
        
        private void FixedUpdate()
        {
            if (_right)
            {
                float newValue = gate.localPosition.x + speed;
                if (newValue < distanceRight)
                {
                    gate.localPosition = new Vector3(newValue, 0, 0);
                }
                else
                {
                    gate.localPosition = new Vector3(distanceRight, 0, 0);
                    _right = false;
                }
            }
            else
            {
                float newValue = gate.localPosition.x - speed;
                if (newValue > -distanceLeft)
                {
                    gate.localPosition = new Vector3(newValue, 0, 0);
                }
                else
                {
                    gate.localPosition = new Vector3(-distanceLeft, 0, 0);
                    _right = true;
                }
            }
        }
    }
}
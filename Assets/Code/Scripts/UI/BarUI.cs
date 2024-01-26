using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.UI
{
    public class BarUI : MonoBehaviour
    {
        [SerializeField] private Image image;

        private void Awake()
        {
            SetValue(0);
        }

        public void SetValue(float value)
        {
            image.fillAmount = value;
        }
    }
}

using System;
using UnityEngine;

namespace Code.Scripts.ColorSystem
{
    public class ColorManager : MonoBehaviour
    {
        public static ColorManager instance;
        
        [SerializeField] private ColorPool colors;

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public Color GetColor(int index) => colors.GetColor(index);
    }
}

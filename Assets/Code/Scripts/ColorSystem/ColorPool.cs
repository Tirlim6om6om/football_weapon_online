using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.ColorSystem
{
    [CreateAssetMenu(fileName = "Color", menuName = "Colors", order = 0)]
    public class ColorPool : ScriptableObject
    {
        [SerializeField] private List<Color> colors;

        public Color GetColor(int index) => colors[index];
    }
}
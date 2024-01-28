using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.ColorSystem
{
    public class ColorViewUI : MonoBehaviour, IColorSetter
    {
        public void SetColor(Color color)
        {
            if (TryGetComponent(out Image image))
            {
                image.color = color;
            }       
        }
    }
}
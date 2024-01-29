using UnityEngine;

namespace Code.Scripts.ColorSystem
{
    public class ColorViewMesh : MonoBehaviour, IColorSetter
    {
        public void SetColor(Color color)
        {
            if (TryGetComponent(out MeshRenderer meshRenderer))
            {
                meshRenderer.material.SetColor("_Color", color);
            }
        }
    }
}
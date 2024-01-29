using UnityEngine;

namespace Code.Scripts.ColorSystem
{
    public class ColorViewMeshEmission : MonoBehaviour, IColorSetter
    {
        [SerializeField] private int index;
        
        public void SetColor(Color color)
        {
            if (TryGetComponent(out MeshRenderer meshRenderer))
            {
                meshRenderer.materials[index].SetColor("_EmissionColor", color);
            }
        }
    }
}
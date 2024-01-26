using TMPro;
using UnityEngine;

namespace Code.Scripts.Gate
{
    public class PlayerScore : MonoBehaviour
    {
        public int id;

        [SerializeField] private TextMeshProUGUI textScore;
        
        private int _score;

        public void ChangePoints(int idShell)
        {
            _score += id == idShell ? 1 : -1;
            textScore.text = _score.ToString();
        }

        public int GetScore() => _score;
    }
}

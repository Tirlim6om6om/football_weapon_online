using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class BeginButton : MonoBehaviour
    {
        public void LoadMain()
        {
            PhotonNetwork.LoadLevel("Main");
        }
    }
}

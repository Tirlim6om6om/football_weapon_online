using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class BeginButton : MonoBehaviour
    {
        public void LoadMain()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel("Main");
        }
    }
}

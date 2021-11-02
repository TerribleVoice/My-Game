using Photon.Pun;
using UnityEngine;

namespace Multiplayer
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public GameObject PlayerPrefab;
        void Start()
        {
            var startPos = new Vector3(0, 1.5f, 0);
            PhotonNetwork.Instantiate(PlayerPrefab.name, startPos, Quaternion.identity);
        }

        void Update()
        {

        }
    }
}

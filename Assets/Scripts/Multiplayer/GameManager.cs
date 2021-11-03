using System;
using Global;
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
            var player = PhotonNetwork.Instantiate(PlayerPrefab.name, startPos, Quaternion.identity).GetComponent<Player>();

            PlayerList.CreatePlayer(PhotonHelper.LocalPlayerId, PhotonNetwork.NickName, player);
        }

        void Update()
        {

        }
    }
}

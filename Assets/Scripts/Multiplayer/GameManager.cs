using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ExitGames.Client.Photon;
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
            RegisterSerialization();
            var startPos = new Vector3(0, 1.5f, 0);
            var player = PhotonNetwork.Instantiate(PlayerPrefab.name, startPos, Quaternion.identity).GetComponent<Player>();
            Local.Player = player;
        }

        private void RegisterSerialization()
        {
            PhotonPeer.RegisterType(typeof(Guid), Serializer.GuidCode, Serializer.SerializeGuid, Serializer.DeserializeGuid);
            PhotonPeer.RegisterType(typeof(Player), Serializer.PlayerCode, Serializer.SerializePlayer, Serializer.DeserializePlayer);
        }
    }
}

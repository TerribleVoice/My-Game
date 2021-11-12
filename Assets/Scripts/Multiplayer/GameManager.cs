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
        public Transform Spawn;
        void Start()
        {
            RegisterSerialization();
            var player = PhotonNetwork.Instantiate(PlayerPrefab.name, Spawn.position, Quaternion.identity).GetComponent<Player>();
            Local.Player = player;
        }

        private void RegisterSerialization()
        {
            PhotonPeer.RegisterType(typeof(Guid), Serializer.GuidCode, Serializer.SerializeGuid, Serializer.DeserializeGuid);
            PhotonPeer.RegisterType(typeof(Player), Serializer.PlayerCode, Serializer.SerializePlayer, Serializer.DeserializePlayer);
        }
    }
}

using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Multiplayer
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        public Text LogText;
        private void Awake()
        {
            PhotonNetwork.NickName = $"Player {Random.Range(1, 100)}";
            Log("Player's name is set to " + PhotonNetwork.NickName);

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 3 });
        }

        public void JoinRandomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            Log("joined the room");
            SceneManager.LoadScene("Game");
        }

        private void Log(string message)
        {
            print(message);
            LogText.text += "\n";
            LogText.text += message;
        }

        public override void OnConnectedToMaster()
        {
            Log("Connected To Master");
        }
    }
}

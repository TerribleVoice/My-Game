using System;
using UnityEngine;

namespace Multiplayer
{
    public class Player : MonoBehaviour
    {
        public PlayerInfo PlayerInfo;
        public Camera Camera;
        public CharacterController Controller;

        private void Awake()
        {
            PlayerInfo = new PlayerInfo();
        }

        void Update()
        {

        }
    }
}

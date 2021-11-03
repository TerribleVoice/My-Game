﻿using System;
using Multiplayer;
using Photon.Pun;
using UnityEngine;

namespace UI
{
    public class UIMenu : MonoBehaviour
    {
        public MouseLook MouseLook;
        public bool IsActive { get; private set; }

        private void Awake()
        {
            MouseLook = PlayerList.GetLocalPlayer().Camera.GetComponent<MouseLook>();
        }

        public void SwitchActivityState()
        {
            ChangeActivityState(!IsActive);
        }

        public void Activate()
        {
            ChangeActivityState(true);
        }

        public void Disable()
        {
            ChangeActivityState(false);
        }

        private void ChangeActivityState(bool isActive)
        {
            IsActive = isActive;
            gameObject.SetActive(isActive);
            MouseLook.IsLocked = isActive;
            Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
        }

    }
}

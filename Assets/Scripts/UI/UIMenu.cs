using System;
using Global;
using Multiplayer;
using Photon.Pun;
using UnityEngine;

namespace UI
{
    public class UIMenu : MonoBehaviour
    {
        private MouseLook mouseLook;
        public bool IsActive { get; private set; }

        private void Awake()
        {
            mouseLook = Local.Player.Camera.GetComponent<MouseLook>();
        }

        public void SwitchActivityState()
        {
            ChangeActivityState(!IsActive);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyMap.CloseMenu))
            {
                Disable();
            }
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
            mouseLook.IsLocked = isActive;
            Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
        }

    }
}

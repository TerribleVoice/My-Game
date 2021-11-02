using System;
using Photon.Pun;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity;
    public bool IsLocked;
    private PhotonView photonView;
    private Transform playerBody;
    private float xRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        photonView = GetComponentInParent<PhotonView>();
        playerBody = photonView.transform;
        Debug.LogWarning(photonView);
    }

    private void Start()
    {
        if(!photonView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void Update()
    {
        print("camera " + photonView.Controller.NickName + ":" + playerBody.transform.position);

        if (IsLocked || !photonView.IsMine)
            return;

        var mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

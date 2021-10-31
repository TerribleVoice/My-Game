using System;
using UnityEditor;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity;
    public Transform PlayerBody;
    public bool IsLocked;
    private float xRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (IsLocked)
        {
            return;
        }

        var mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}

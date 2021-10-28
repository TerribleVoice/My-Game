using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public  float MouseSensitivity = 100;
    public Transform PlayerBody;
    private float xRotation;

    private void Start()
    {
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}

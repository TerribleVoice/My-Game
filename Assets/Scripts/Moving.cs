using System;
using Global;
using Photon.Pun;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float Speed;
    public float Gravity;
    public float JumpHeight;

    private CharacterController controller;
    private Transform groundCheck;
    public LayerMask GroundLayer;

    private float verticalVelocity;
    private PhotonView photonView;
    private bool isGrounded;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        controller = photonView.GetComponent<CharacterController>();
        groundCheck = GetComponentInChildren<GroundCheck>().transform;
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        GravityLogic();
        MovementLogic();
    }

    private void GravityLogic()
    {
        isGrounded = false;
        if (isGrounded)
            verticalVelocity = 0f;

        if (isGrounded && Input.GetKeyDown(KeyMap.Jump))
            verticalVelocity = Mathf.Sqrt(JumpHeight * 2 * Gravity);

        verticalVelocity -= Gravity * Time.deltaTime;
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    private void MovementLogic()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var direction = transform.right * x + transform.forward * z;
        controller.Move(direction * Speed * Time.deltaTime);
    }
}

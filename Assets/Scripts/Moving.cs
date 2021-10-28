using UnityEngine;

public class Moving : MonoBehaviour
{
    public float Speed;
    public float Gravity;
    public float JumpHeight;

    public CharacterController Controller;
    public LayerMask GroundMask;
    public Transform GroundCheck;

    private float verticalVelocity = 0;

    private void Update()
    {
        GravityLogic();
        MovementLogic();
    }

    private void GravityLogic()
    {
        var isGrounded = Physics.CheckSphere(GroundCheck.position, 0.2f, GroundMask);
        if (isGrounded)
        {
            verticalVelocity = 0f;
        }

        if (isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = Mathf.Sqrt(JumpHeight * 2 * Gravity);
        }

        verticalVelocity -= Gravity * Time.deltaTime;
        Controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    private void MovementLogic()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var direction = transform.right * x + transform.forward * z;
        Controller.Move(direction * Speed * Time.deltaTime);

    }
}

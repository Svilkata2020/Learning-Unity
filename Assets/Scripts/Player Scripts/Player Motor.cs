using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private float defaultSpeed = 5f;
    private float crouchSpeed = 2.5f;
    private float sprintSpeed = 8f;
    public float speed = 5.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    void Start()
    {
        speed = defaultSpeed;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection.normalized) * Time.deltaTime * speed);

        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * gravity * -2);
        }
    }

    public void Crouch()
    {
        if(isGrounded)
        {
            speed = crouchSpeed;
        }
    }

    public void Sprint()
    {
        if (isGrounded)
        {
            speed = sprintSpeed;
        }
    }

    public void Walk()
    {
        speed = defaultSpeed;
    }
}

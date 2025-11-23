using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private bool isJumping = false;
    private bool isCrouching = false;
    private bool isSprinting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        onFoot.Jump.started += ctx => isJumping = true;
        onFoot.Jump.canceled += ctx => isJumping = false;
        onFoot.Crouch.started += ctx => isCrouching = true;
        onFoot.Crouch.canceled += ctx => isCrouching = false;
        onFoot.Sprint.started += ctx => isSprinting = true;
        onFoot.Sprint.canceled += ctx => isSprinting = false;

        look = GetComponent<PlayerLook>();
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if(isJumping)
        {
            motor.Jump();
        }
        if (isCrouching) 
        {
            motor.Crouch();
        }
        if (isSprinting)
        {
            motor.Sprint();
        }
        if(!isSprinting && !isCrouching)
        {
            motor.Walk();
        }
    }

    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}

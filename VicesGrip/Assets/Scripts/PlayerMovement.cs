using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 movementInput;
    private PlayerInputActions playerInputActions;
    private Vector2 mousePosition;
    private Camera mainCamera;
    private Vector2 prev_mousePosition;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        mainCamera = GetComponentInChildren<Camera>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    private void Update()
    {
        // Get the input from the Input System
        movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        // Debug.Log(movementInput);

        mousePosition = playerInputActions.Player.Look.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        // moveDirection.Normalize();

        // // Move the player
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);

        if (mousePosition != prev_mousePosition){
            // Debug.Log(mousePosition);
            // Debug.Log(prev_mousePosition);
            Vector3 mousePosition_screenPoint = Camera.main.ScreenPointToRay(mousePosition).direction;
            Debug.Log(mousePosition_screenPoint);
            mousePosition_screenPoint.Normalize();

            // Vector3 relativePos = mousePosition_screenPoint- transform.position;

            // the second argument, upwards, defaults to Vector3.up
            // Quaternion rotation = Quaternion.LookRotation(mousePosition_screenPoint, Vector3.up);
            // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
        }

        

        prev_mousePosition = mousePosition;

    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump!");
        }
    }
}

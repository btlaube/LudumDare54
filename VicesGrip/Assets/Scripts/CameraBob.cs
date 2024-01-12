using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraBob : MonoBehaviour
{
    public float bobFrequency = 1.0f; // How fast the camera bobs.
    public float bobAmplitude = 0.1f; // How much the camera bobs.
    public float sprintBobFrequency;
    public float sprintBobAmplitude;

    public GroundCheck groundCheck;

    private float currentBobFrequency;
    private float currentBobAmplitude;
    private float timer = 0.0f;
    private Vector3 initialPosition;

    // private PlayerInput playerInput;
    private Vector2 movementInput;
    private float sprintInput;
    private PlayerInputActions playerInputActions;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Get player input (e.g., from character controller or input system).
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        sprintInput = playerInputActions.Player.Sprint.ReadValue<float>();

        // Change frequency and amplitude if sprinting or not
        if (sprintInput > 0)
        {
            currentBobFrequency = sprintBobFrequency;
            currentBobAmplitude = sprintBobAmplitude;
        }
        else
        {
            currentBobFrequency = bobFrequency;
            currentBobAmplitude = bobAmplitude;
        }

        if (groundCheck && groundCheck.isGrounded)
        {
            // Calculate bobbing motion based on player's movement.
            float bobX = Mathf.Sin(timer * currentBobFrequency) * currentBobAmplitude * Mathf.Clamp01(Mathf.Abs(movementInput.x) + Mathf.Abs(movementInput.y));
            float bobY = Mathf.Cos(timer * currentBobFrequency * 2) * currentBobAmplitude * Mathf.Clamp01(Mathf.Abs(movementInput.x) + Mathf.Abs(movementInput.y));

            // Apply the bobbing motion to the camera's local position.
            Vector3 newLocalPosition = initialPosition + new Vector3(bobX, bobY, 0.0f);
            transform.localPosition = newLocalPosition;

            // Update the timer to control the bobbing animation.
            timer += Time.deltaTime;
        }
    }
}

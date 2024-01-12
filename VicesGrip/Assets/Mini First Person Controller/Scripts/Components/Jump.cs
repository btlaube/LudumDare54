using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;

    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += JumpPerformed;
    }

    // void LateUpdate()
    // {
    //     // Jump when the Jump button is pressed and we are on the ground.
    //     if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
    //     {
    //         rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
    //         Jumped?.Invoke();
    //     }
    // }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        if ((!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}

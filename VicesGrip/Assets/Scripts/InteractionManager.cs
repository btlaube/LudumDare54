using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    public GameManager gameManager;

    public float raycastDistance = 10f; // The maximum distance of the raycast
    public LayerMask interactableLayer; // The layer to check for interactable objects

    public Transform interactionObjectAnchor;
    public Equippable heldEquippable;

    // Controll Crosshair appearance
    public Image crosshair;
    public Color crosshairDefault = Color.white;
    public Color crosshairHover = Color.green;

    // Check for key
    private bool hasKey;

    // Input
    private PlayerInputActions playerInputActions;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact;
    }

    void Update()
    {
        // Create a raycast from the object's position forward
        // Debug.Log(transform);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check if the ray hits something on the interactable layer
        if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
        {
            // Debug the name of the object hit
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            
            // Update crosshair appearance
            crosshair.color = crosshairHover;
        }
        else
        {
            // Reset crosshair appearance
            crosshair.color = crosshairDefault;
        }

        // Draw the ray in the scene view
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        
        if (heldEquippable != null)
        {
            heldEquippable.Drop();
            heldEquippable = null;
            return;
        }

        // Create a raycast from the object's position forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check if the ray hits something on the interactable layer
        if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
        {

            

            // Debug the name of the object hit
            // Debug.Log("Interacted with: " + hit.collider.gameObject.name);
            // hit.collider.transform.position = interactionObjectAnchor.position;
            // Equip object (lock its position to object anchor)
            heldEquippable = hit.collider.gameObject.GetComponent<Equippable>();
            Panel panelDoor = hit.collider.gameObject.GetComponent<Panel>();
            Key key = hit.collider.gameObject.GetComponent<Key>();
            Box box = hit.collider.gameObject.GetComponent<Box>();
            KeyPadButton keypadButton = hit.collider.gameObject.GetComponent<KeyPadButton>();
            if (heldEquippable != null)
            {
                // trigger interact event
                // hit.collider.transform.position = interactionObjectAnchor.position;
                heldEquippable.PickUp(interactionObjectAnchor);
                if (hit.collider.gameObject.tag == "Trashbag")
                {
                    gameManager.DisplayMessage("killer: Digging around in the trash, detective?");
                }
            }
            else if (panelDoor != null)
            {
                if(hasKey)
                {
                    panelDoor.OpenOrClose();
                }
                else
                {
                    // Debug.Log("The panel is locked");
                    gameManager.DisplayMessage("The panel appears to be locked");
                }
            }
            else if(key != null)
            {
                key.PickUp();
                hasKey = true;
                gameManager.DisplayMessage("killer: Looks like you found a key. You still won't escape");
            }
            else if (box != null)
            {
                box.OpenOrClose();
            }
            else if (keypadButton != null)
            {
                keypadButton.Clicked();
            }
            else if (hit.collider.gameObject.tag == "BigDoor")
            {
                gameManager.DisplayMessage("Use the keypad to unlock the door");
            }
            else
            {
                gameManager.DisplayMessage("killer: Digging around in the trash, detective?");
            }
        }
    }

}

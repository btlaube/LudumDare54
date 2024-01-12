using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{

    public Vector3 equippedRotation;

    private Rigidbody rigidbody;
    private Collider collider;
    private Transform oldParent;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    public void PickUp(Transform newParent)
    {
        oldParent = transform.parent;
        // Debug.Log(oldParent);
        Debug.Log("Picked up: " + this.name);
        transform.parent = newParent;
        transform.position = newParent.position;
        rigidbody.isKinematic  = true;
        collider.enabled = false;

        // Rotate object
        // Record the original world rotation
        Quaternion originalWorldRotation = transform.rotation;

        // Set the local rotation
        transform.localRotation = Quaternion.Euler(equippedRotation);

        // Restore the original world rotation
        // transform.rotation = originalWorldRotation;
        
    }

    public void Drop()
    {
        Debug.Log("Dropped: " + this.name);
        rigidbody.isKinematic  = false;
        collider.enabled = true;
        // Debug.Log(oldParent);
        transform.parent = oldParent;
    }

}

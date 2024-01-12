using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // Define a Unity Event called interactEvent
    // [System.Serializable]
    // public class InteractEvent : UnityEvent { }

    public UnityEvent interactEvent;

    // This function can be called to trigger the interactEvent
    public void Interact()
    {
        if (interactEvent != null)
        {
            interactEvent.Invoke();
        }
    }

    public void OpenPanel()
    {
        Debug.Log("Panel openned");
    }

    public void Equip()
    {
        Debug.Log("Equipped object: " + this.name);
    }

}

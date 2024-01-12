using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyPadButton : MonoBehaviour
{
    public KeypadManager keypad;
    public UnityEvent clickEvent;

    public AudioSource audio;

    public void Clicked()
    {
        audio.Play();
        clickEvent.Invoke();
    }
}

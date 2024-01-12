using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private bool isOpen;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        isOpen = false;
    }

    public void OpenOrClose()
    {
        if (isOpen)
        {
            Close();
        }
        else{
            Open();
        }
    }

    public void Open()
    {
        isOpen = true;
        // Debug.Log("Open Panel");
        animator.SetTrigger("Open");
    }

    public void Close()
    {
        isOpen = false;
        // Debug.Log("Close Panel");
        animator.SetTrigger("Close");
    }
}

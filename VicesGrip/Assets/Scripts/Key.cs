using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Image keyImage;

    private void Start()
    {
        keyImage.enabled = false;
    }

    public void PickUp()
    {
        keyImage.enabled = true;
        Destroy(gameObject);
    }
}

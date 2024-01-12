using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Animator gameMessageAnimator;
    public TextMeshProUGUI gameMessageText;

    private void Start()
    {
        gameMessageText.text = "";
        // DisplayMessage("This is a test");
    }

    public void DisplayMessage(string message)
    {
        gameMessageText.text = message;
        gameMessageAnimator.SetTrigger("Show");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public WallManager wallManager;
    public GameManager gameManager;
    public CountdownTimer countdownTimer;

    public AudioSource audio;

    private string code = "6428";
    private string dashes = "----";
    private string currentEntry = "";

    private LevelLoader levelLoader;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    private void UpdateDisplay()
    {
        textMeshPro.text = currentEntry + dashes.Substring(0, 4 - currentEntry.Length);
    }

    public void TypeNumber(string number)
    {
        if (currentEntry.Length < 4)
        {
            currentEntry += number;
            // Debug.Log("typed a " + number);
            
            UpdateDisplay();
        }
        
    }

    public void CheckEntry()
    {
        if (currentEntry == code)
        {
            // Debug.Log("Correct");
            audio.Play();
            levelLoader.LoadWinScene();
        }
        else
        {
            // Debug.Log("Incorrect");
            // Lose time
            gameManager.DisplayMessage("Killer: Wrong code! Just for that you lose a minute hahaha");
            countdownTimer.LoseTime(60f);
            // Move walls
            wallManager.MoveAllWalls();
            ClearEntry();
        }
    }

    public void ClearEntry()
    {
        currentEntry = "";

        UpdateDisplay();
    }

}

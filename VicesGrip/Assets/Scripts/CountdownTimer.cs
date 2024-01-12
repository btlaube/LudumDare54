using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{

    public WallManager wallManager;

    public float countdownTime = 60.0f; // Set the initial countdown time in seconds
    public float callFunctionInterval = 300.0f; // Set the interval in seconds to call a function (e.g., 5 minutes)
    public TextMeshProUGUI textMeshPro;

    public AudioSource audio;
    private float audioTimer = 0.0f;
    
    private float currentTime;    
    private float timeSinceLastFunctionCall = 0.0f;

    private LevelLoader levelLoader;
    private bool loadedLoseScene = false;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    private void Start()
    {
        currentTime = countdownTime;
        UpdateTimerText();
    }

    private void Update()
    {
        // Update the countdown timer
        currentTime -= Time.deltaTime;

        if (currentTime <= 0.0f && !loadedLoseScene)
        {
            currentTime = 0.0f; // Ensure the timer doesn't go below zero
            // You can add code here to handle what happens when the countdown reaches zero
            loadedLoseScene = true;
            levelLoader.LoadLoseScene();
        }

        // Update the time since the last function call
        timeSinceLastFunctionCall += Time.deltaTime;

        // Check if it's time to call the function
        if (timeSinceLastFunctionCall >= callFunctionInterval)
        {
            // Call your custom function here
            wallManager.MoveAllWalls();

            // Reset the time since the last function call
            timeSinceLastFunctionCall = 0.0f;
        }

        // Sound
        audioTimer += Time.deltaTime;
        if (audioTimer >= 1f)
        {
            audio.Play();
            audioTimer = 0.0f;
        }

        UpdateTimerText();
    }

    public void LoseTime(float time)
    {
        currentTime -= time;
    }

    private void UpdateTimerText()
    {
        // Update the TextMeshPro component with the current time
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

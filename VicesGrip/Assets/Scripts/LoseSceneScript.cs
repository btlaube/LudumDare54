using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSceneScript : MonoBehaviour
{

    private LevelLoader levelLoader;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    public void Retry()
    {
        levelLoader.LoadIntroScene();
    }

    public void MainMenu()
    {
        levelLoader.LoadMainMenu();
    }

}

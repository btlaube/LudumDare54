using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public Animator loseTransition;
    public Animator winTransition;

    public GameObject winTransitionCanvas;
    public GameObject loseTransitionCanvas;

    private Animator transition;

    [SerializeField] private float transitionTime = 1f;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        winTransitionCanvas.SetActive(true);
        loseTransitionCanvas.SetActive(false);
        transition = winTransition;
        // transition.enabled = true;
        // LoadMainMenu();
    }

    public void LoadMainMenu() {
        winTransitionCanvas.SetActive(true);
        loseTransitionCanvas.SetActive(false);
        transition = winTransition;
        StartCoroutine(LoadLevel(0));
    }

    public void LoadGameScene() {
        winTransitionCanvas.SetActive(true);
        loseTransitionCanvas.SetActive(false);
        transition = winTransition;
        StartCoroutine(LoadLevel(1));
    }

    public void LoadWinScene() {
        winTransitionCanvas.SetActive(true);
        loseTransitionCanvas.SetActive(false);
        transition = winTransition;
        StartCoroutine(LoadLevel(2));
    }

    public void LoadLoseScene() {
        winTransitionCanvas.SetActive(false);
        loseTransitionCanvas.SetActive(true);
        transition = loseTransition;
        StartCoroutine(LoadLevel(3));
    }

    public void LoadIntroScene() {
        winTransitionCanvas.SetActive(true);
        loseTransitionCanvas.SetActive(false);
        transition = winTransition;
        StartCoroutine(LoadLevel(4));
    }

    public void LoadScene(int sceneToLoad) {
        StartCoroutine(LoadLevel(sceneToLoad));
    }

    IEnumerator LoadLevel(int levelIndex) {
        // transition.enabled = true;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        transition.SetTrigger("End");
    }

    public void Quit() {
        Application.Quit();
    }
}

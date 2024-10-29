using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject conductor;
    public GameObject noteSpawner;
    [SerializeField] int mainMenuSceneIndex;

    [SerializeField] Animator menuAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

        Debug.Log("start");
        menuAnimator.SetTrigger("Start");

        conductor.SetActive(true);
        noteSpawner.SetActive(true);
    }

    public void QuitGame()
    {

        Application.Quit();
        Debug.Log("quit");
    }

    public void PauseGame()
    {

        //Time.timeScale = 0;
    }

    public void ResumeGame()
    {

        //Time.timeScale = 1;
    }

    public void LoadMainMenu() {

        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}

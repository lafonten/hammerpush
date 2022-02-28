using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{
    private PlayerControler pCon;
    public static SceneControler sCon;

    public bool CanStartGame = false;

    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject StartButton;

    private void Start()
    {
        sCon = this;
        pCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
    }

    public void StartGame()
    {
        CanStartGame = true;
        RestartButton.SetActive(true);
        StartButton.SetActive(false);
    }

    public void RestartGame()
    {
        int scene_index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene_index);
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ApplicationExit()
    {
        Application.Quit();
    }
}

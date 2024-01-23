using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameSession gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneIndex+1);
    }

    public void LoadFirstScene()
    {
        gameStatus.ResetGame();
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

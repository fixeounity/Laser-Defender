using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float gameOverDelayDuration = 1f;

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverWithDelay());
    }

    private IEnumerator LoadGameOverWithDelay()
    {
        yield return new WaitForSeconds(gameOverDelayDuration);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void LoadGameScene()
    {
        FindObjectOfType<GameSession>().ResetGame();

        SceneManager.LoadScene(1);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

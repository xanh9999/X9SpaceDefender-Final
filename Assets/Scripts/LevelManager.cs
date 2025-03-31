using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] float loadGameDelayTime = 1.5f;
    Score scoreKeeper;

    // void Awake()
    // {
    //     scoreKeeper = FindObjectOfType<Score>();
    // }
    
    public void LoadGame()
    {   
        scoreKeeper = FindObjectOfType<Score>();
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", loadGameDelayTime));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

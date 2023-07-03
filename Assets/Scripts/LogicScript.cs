using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject theEndScreen;

    [ContextMenu("Turn on GameOver")]
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    [ContextMenu("Turn on TheEnd")]

    public void TheEnd()
    {
        theEndScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuLogic : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject controlInfo;

    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Controls()
    {
        mainMenu.gameObject.SetActive(false);
        controlInfo.gameObject.SetActive(true);
    }
    
    
    public void ControlsBack()
    {
        controlInfo.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }



}

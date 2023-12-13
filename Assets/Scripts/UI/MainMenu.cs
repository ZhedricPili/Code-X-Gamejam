using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //as per kyle's request made a variable to add whatever gameobject they please
    [Tooltip("Place the Option gameobject here")]
    public GameObject optionsScreen;
    
    void Start()
    {
        optionsScreen.SetActive(false);
    }
    
    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        optionsScreen.SetActive(true);
    }

    public void GameEnd()
    {
        Application.Quit();
    }
}

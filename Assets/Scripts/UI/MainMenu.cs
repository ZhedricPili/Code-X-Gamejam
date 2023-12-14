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
    
    public void GameStarter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsEnabler()
    {
        optionsScreen.SetActive(true);
    }

    public void GameEnder()
    {
        Application.Quit();
        Debug.Log("Game Over     SNAKKEEEEE");
    }
    public void OptionDisabler()
    {
        optionsScreen.SetActive(false);
    }
}

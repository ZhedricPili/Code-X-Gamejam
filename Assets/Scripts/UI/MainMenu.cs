using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [Tooltip("Place Corresponding Screen Game Object")]
    public GameObject screenObject;
    
    public void GameStarter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    [Tooltip("Enables the Object placed inside")]
    public void Enabler(GameObject gameScreen)
    {
        gameScreen.SetActive(true);
    }
    public void Disabler(GameObject gameScreen)
    {
        gameScreen.SetActive(false);
    }
    public void GameEnder()
    {
        Application.Quit();
        Debug.Log("Game Over     SNAKKEEEEE");
    }
}

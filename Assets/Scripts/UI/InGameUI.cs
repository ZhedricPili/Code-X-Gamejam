using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _overlayObjects; //In-game Interface, BG, Pause Overlay, Game Overlay
    public static bool gameIsPaused;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            
            if(gameIsPaused == true)
            {
                PauseGame();
            }
            else if (gameIsPaused == false)
            {
                ResumeGame();
            }            
        }
    }

    

    public void PauseGame()
    {
        Debug.Log("Paused");
        Time.timeScale = 0;
        gameIsPaused = true;

        _overlayObjects[0].SetActive(false);
        _overlayObjects[1].SetActive(true);
        _overlayObjects[2].SetActive(true);
    }
    public void ResumeGame()
    {
        Debug.Log("Resume");
        Time.timeScale = 1;
        gameIsPaused = false;

        _overlayObjects[0].SetActive(true);
        _overlayObjects[1].SetActive(false);
        _overlayObjects[2].SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _overlayObjects[0].SetActive(false);
        _overlayObjects[1].SetActive(true);
        _overlayObjects[3].SetActive(true);
    }
}

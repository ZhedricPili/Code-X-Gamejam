using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveChecker : MonoBehaviour
{
    public int winAmount;
    [Tooltip("Place WinScreen here")]
    public GameObject winScreen;
    PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WinCheck();
    }
    void WinCheck()
    {
    if(playerInventory.objectiveCounter == winAmount)
        {
            Debug.Log("winner");
            winScreen.SetActive(true);
        }
    }
}

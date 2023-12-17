using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    //The variable can be read by other scripts but only be set here
    public int objectiveCounter {get; private set;}
    public TextMeshProUGUI scoreText;

    public void Update()
    {
        if (objectiveCounter == 5)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            objectiveCounter = 0;
        }
        scoreText.text = objectiveCounter.ToString();
    }

    public void ObjectiveCollector()
    {
        objectiveCounter++;
    }
}

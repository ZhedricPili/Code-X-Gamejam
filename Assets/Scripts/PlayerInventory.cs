using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //The variable can be read by other scripts but only be set here
    public int objectiveCounter {get; private set;}

    public void ObjectiveCollector()
    {
        objectiveCounter++;
    }
}

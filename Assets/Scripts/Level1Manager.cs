using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject manager;

    public Transform[] BookSpawn;

    public GameObject book;
    void Awake()
    {
        SpawnBook();
    }

     void OnEnable()
    {
        //Debug.Log("New Book spawned");
        PlayerInventory.onBookTaken += SpawnBook;
    }


    void SpawnBook()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, BookSpawn.Length - 1));

        Instantiate(book, BookSpawn[randomNumber].transform.position, Quaternion.identity);
    }
}

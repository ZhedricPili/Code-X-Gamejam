using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    [SerializeField] string SoundName;
    [SerializeField] List<AudioClip> soundList = new List<AudioClip>();
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(soundList[Random.Range(0, soundList.Count)]);
    }
}

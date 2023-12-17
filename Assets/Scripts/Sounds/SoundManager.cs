using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _mainSource, _footstepsSource;
    [SerializeField] private List<AudioClip> _footstepSounds = new List<AudioClip>();
    
    public void RandomizeSound(List<AudioClip> randomSound, AudioSource audioSource)
    {
        audioSource.PlayOneShot(randomSound[Random.Range(0, randomSound.Count)]);
    }
    public AudioSource MainSource
    {
        get { return _mainSource; }
    }
    public AudioSource FootstepsSource
    {
        get { return _footstepsSource; }
    }
    public List<AudioClip> FootstepSounds
    {
        get { return _footstepSounds; }
    }
}

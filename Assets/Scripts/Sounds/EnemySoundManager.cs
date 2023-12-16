using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : SoundManager
{
    [SerializeField] private List<AudioClip> snatchSound = new List<AudioClip>();
    private SoundManager _soundManager;

    void Start()
    {
        _soundManager = GetComponent<SoundManager>();
    }

    public void PlaySnatchPlayer()
    {
        RandomizeSound(snatchSound, _soundManager.MainSource);
    }
}

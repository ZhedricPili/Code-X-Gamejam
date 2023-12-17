using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : SoundManager
{
    [SerializeField] private List<AudioClip> _collectSounds = new List<AudioClip>();
    private SoundManager _soundManager;
   
    void Start()
    {
        _soundManager = GetComponent<SoundManager>();
    }
    public void PlayBookCollect()
    {
        RandomizeSound(_collectSounds, _soundManager.MainSource);
    }
}

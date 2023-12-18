using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    [SerializeField] private SoundManager _characterSoundManager;
    //[SerializeField] private SoundManager _soundManager;
    private List<AudioClip> footstepSounds;
    // Start is called before the first frame update
    void Start()
    {
        //_soundManager = GetComponent<SoundManager>();
        footstepSounds = _characterSoundManager.FootstepSounds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootsteps()
    {
        _characterSoundManager.RandomizeSound(footstepSounds, _characterSoundManager.MainSource);
    }
}

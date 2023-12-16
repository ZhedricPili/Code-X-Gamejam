using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    [SerializeField] private SoundManager _characterSoundManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootsteps()
    {
        _characterSoundManager.RandomizeSound(_collectSounds, _soundManager.MainSource)
    }
}

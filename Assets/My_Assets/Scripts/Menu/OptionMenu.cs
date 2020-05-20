using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixer2;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetSounds (float sounds)
    {
        audioMixer2.SetFloat("Volume", sounds);
    }

    
}

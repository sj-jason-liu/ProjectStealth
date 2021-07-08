using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance; //variable to access
    public static AudioManager Instance //public property to retrieve this instance
    {
        get
        {
            if(_instance == null) //check if instance is null
            {
                Debug.LogError("AudioManager is missing!");
            }
            return _instance;
        }
    }

    private void Awake() //assign this instance to "this"
    {
        _instance = this;
    }

    [SerializeField]
    private AudioSource _voiceOver;

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        _voiceOver.clip = clipToPlay;
        _voiceOver.Play();
    }
}

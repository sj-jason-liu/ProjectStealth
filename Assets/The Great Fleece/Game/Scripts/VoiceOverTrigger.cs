using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioClip;

    private bool _clipHasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !_clipHasPlayed)
        {
            AudioManager.Instance.PlayVoiceOver(_audioClip);
            _clipHasPlayed = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCaller : MonoBehaviour
{
    private bool _hasTriggered = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !_hasTriggered)
        {
            AudioManager.Instance.PlayMusic();
            _hasTriggered = true;
        }
    }
}

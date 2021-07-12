using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameoverCutscene;

    private bool _hasDetected = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !_hasDetected)
        {
            _gameoverCutscene.SetActive(true);
            _hasDetected = true;
        }
    }
}

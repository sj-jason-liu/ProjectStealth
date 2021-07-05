using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    //ontriggerenter check player
    //if so, play cutscene
    [SerializeField]
    private GameObject _gameoverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _gameoverCutscene.SetActive(true);
        }
    }
}

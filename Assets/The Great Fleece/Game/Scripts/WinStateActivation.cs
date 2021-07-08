using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    //ontriggerenter
    //check darren
    //check has card
    //trigger win cutscene
    //or print out must has key
    [SerializeField]
    private GameObject _winCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.Instance.HasCard == true)
            {
                _winCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("You must have keycard.");
            }
        }
    }
}

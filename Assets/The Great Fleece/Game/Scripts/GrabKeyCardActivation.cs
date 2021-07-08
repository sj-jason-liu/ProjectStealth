using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _grabCardCutscene;
    [SerializeField]
    private GameObject _keyCard;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _grabCardCutscene.SetActive(true);
            Invoke("DisableCard", 1f);
            GameManager.Instance.HasCard = true;
        }
    }

    void DisableCard()
    {
        _keyCard.SetActive(false);
    }
}

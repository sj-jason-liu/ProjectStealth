using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameoverCutscene;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Color _color = new Color(0.6f, 0f, 0f, 0.03f);
            GetComponent<MeshRenderer>().material.SetColor("_TintColor", _color);
            _animator.enabled = false;
            Invoke("EndingCutscene", 0.5f);
        }    
    }

    void EndingCutscene()
    {
        _gameoverCutscene.SetActive(true);
    }
}

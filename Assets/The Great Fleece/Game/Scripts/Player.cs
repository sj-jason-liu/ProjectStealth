using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //create variable to storage navmeshagent
    private NavMeshAgent _navMeshAgent;

    private Animator _animator;

    [SerializeField]
    private AudioClip _coinSoundEffect;

    [SerializeField]
    private GameObject _coinPrefab;

    private GameObject[] _guards;

    private bool _coinTossed = false;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        _guards = GameObject.FindGameObjectsWithTag("Guard1");
        if(_guards == null)
        {
            Debug.LogError("Could not find guards");
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit));
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
        if(_navMeshAgent.remainingDistance < 0.5f)
        {
            _animator.SetBool("Walk", false);
        }
        else
        {
            _animator.SetBool("Walk", true);
        }
        
        if(Input.GetMouseButtonDown(1) && !_coinTossed)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                _animator.SetTrigger("Throw");
                _coinTossed = true;
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSoundEffect, transform.position);
                SendAIToCoinSpot(hitInfo.point);
            }
        }
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        foreach(GameObject guard in _guards)
        {
            guard.GetComponent<GuardAI>().NoticedCoin(coinPos);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //create variable to storage navmeshagent
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    
    void Start()
    {
        //assign navmeshagent
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
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
        
    }
}

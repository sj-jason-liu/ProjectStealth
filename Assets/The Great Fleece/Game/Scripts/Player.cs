using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //create variable to storage navmeshagent
    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        //assign navmeshagent
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
    }
}

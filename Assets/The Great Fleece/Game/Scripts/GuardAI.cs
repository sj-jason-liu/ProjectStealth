using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    private NavMeshAgent _agent;

    private Animator _anim;
    
    [SerializeField]
    private List<Transform> _wayPoints;

    [SerializeField]
    private int _currentTarget;

    private bool _isReversing;
    private bool _targetReached;
    
   void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        if(_anim != null)
        {
            _anim.SetBool("Walk", true);
        }
    }

    void Update()
    {
        if(_wayPoints.Count > 0 && _wayPoints[_currentTarget] != null) //null check debug
        {
            if (_targetReached == false)
            {
                _agent.SetDestination(_wayPoints[_currentTarget].position);
            }
            float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);
            if (distance < 1f)
            {
                if(_wayPoints.Count > 1) //rule for guards who have more than 1 waypoint
                {
                    if(_currentTarget == 0 || _currentTarget > 1)
                    {
                        _targetReached = true;
                        StartCoroutine(WaitBeforeMoving());
                    }

                    switch (_isReversing)
                    {
                        case true:
                            if(_wayPoints.Count > 3 && _currentTarget == _wayPoints.Count - 1)
                            {
                                _currentTarget = 1;
                            }
                            else
                            {
                                _currentTarget--;
                            }
                            break;
                        case false:
                            if(_wayPoints.Count > 3 && _currentTarget == 1)
                            {
                                _currentTarget += Random.Range(1, 3);
                            }
                            else
                            {
                                _currentTarget++;
                            }
                            break;
                    }

                    if (_currentTarget == _wayPoints.Count - 1 || (_wayPoints.Count > 3 && _currentTarget == _wayPoints.Count -2)) //reverse route order
                    {
                        _isReversing = true;
                    }
                    else if (_currentTarget == 0)
                    {
                        _isReversing = false;
                    }
                }
                else
                {
                    _anim.SetBool("Walk", false); //always idle for 1-waypoint guard
                }
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        _anim.SetBool("Walk", false);
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        _targetReached = false;
        _anim.SetBool("Walk", true);
    }
}

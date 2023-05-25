using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject _targetObject;
    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // NavMeshが準備できているなら
        if(_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) {
            _navMeshAgent.SetDestination(_targetObject.transform.position);
        }
    }
}

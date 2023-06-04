using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public GameObject targetObject;
    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // NavMeshが準備できているなら
        if(_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) {
            _navMeshAgent.SetDestination(targetObject.transform.position);
            
            // 時間が経過するごとに敵の速度が増していく
            _navMeshAgent.speed += 0.002f;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseStatus : MonoBehaviour
{
    [SerializeField] private float maxEnemyBaseHP;
    [SerializeField] private float damage;

    private float _nowHp;
    
    public event Action<float> ChangeHP;

    private void Start()
    {
        _nowHp = maxEnemyBaseHP;
    }

    public void Damage()
    {
        if (_nowHp<=0) return;
        
        _nowHp -= damage;
        
        ChangeHP.Invoke(_nowHp);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseStatus : MonoBehaviour
{
    [SerializeField] private float maxEnemyBaseHP;
    [SerializeField] private float damage;

    [Header("now status")]
    [SerializeField] private float nowHP;
    
    public event Action<float> ChangeHP;

    private void Start()
    {
        nowHP = maxEnemyBaseHP;
    }

    public void Damage()
    {
        if (nowHP<=0) return;
        
        nowHP -= damage;
        
        ChangeHP?.Invoke(nowHP);
    }
}

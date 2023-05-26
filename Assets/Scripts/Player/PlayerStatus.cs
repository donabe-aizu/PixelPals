using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private float maxHP;

        [Header("now status")]
        [SerializeField] private float nowHP;

        [SerializeField] private PlayerHitCheck _hitCheck;

        private void Start()
        {
            nowHP = maxHP;

            _hitCheck.DamageAction += AddDamageAction;
        }

        private void AddDamageAction(float damage)
        {
            if (nowHP <= 0) return;
            
            nowHP -= damage;

            if (nowHP <= 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            Debug.Log("死んだ");
        }
    }
}
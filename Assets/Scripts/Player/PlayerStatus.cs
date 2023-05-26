using System;
using UnityEngine;

namespace Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private PlayerHitCheck _hitCheck;
        [SerializeField] private float maxHP;
        public float MaxHP => maxHP;
        [SerializeField] private float damage;

        [Header("now status")]
        [SerializeField] private float nowHP;

        public event Action<float> PlayerHPChangeAction;

        private void Start()
        {
            nowHP = maxHP;

            _hitCheck.DamageAction += AddDamageAction;
        }

        private void AddDamageAction()
        {
            if (nowHP <= 0) return;
            
            nowHP -= damage;
            
            PlayerHPChangeAction?.Invoke(nowHP);

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
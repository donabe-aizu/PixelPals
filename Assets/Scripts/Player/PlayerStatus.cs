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

        [SerializeField] private int killCount = 0;

        public event Action<float> PlayerHPChangeAction;
        public event Action<int> KillCountAction;

        private void Start()
        {
            nowHP = maxHP;

            _hitCheck.DamageAction += AddDamageAction;
        }

        public void AddKillCount()
        {
            killCount++;
            KillCountAction?.Invoke(killCount);
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
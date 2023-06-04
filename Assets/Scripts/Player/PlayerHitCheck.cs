using System;
using UnityEngine;

namespace Player
{
    public class PlayerHitCheck : MonoBehaviour
    {
        public event Action DamageAction;

        private AudioSource _source;

        [SerializeField] private AudioClip playerDamagedSE;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBase"))
            {
                _source.PlayOneShot(playerDamagedSE);
                DamageAction.Invoke();
            }
        }
    }
}
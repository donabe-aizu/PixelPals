using System;
using UnityEngine;

namespace Player
{
    public class PlayerHitCheck : MonoBehaviour
    {
        public event Action DamageAction;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                DamageAction.Invoke();
            }
        }
    }
}
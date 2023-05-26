using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHitCheck : MonoBehaviour
    {
        public event Action<float> DamageAction;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                DamageAction.Invoke(10f);
            }
        }
    }
}
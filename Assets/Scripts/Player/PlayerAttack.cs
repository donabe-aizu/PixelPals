using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackForce = 10f;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
                bullet.GetComponent<Rigidbody>().AddRelativeForce(0,attackForce,0);
            }
        }
    }
}
using System;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject canonPrefab;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackForce = 10f;

        private PlayerStatus _playerStatus;

        private void Awake()
        {
            _playerStatus = this.GetComponent<PlayerStatus>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
                bullet.GetComponent<Rigidbody>().AddRelativeForce(0,attackForce,0);
                bullet.GetComponent<Bullet>().OnKillEnemy += _playerStatus.AddKillCount;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                if (canonPrefab.transform.localEulerAngles.x > 180f)
                {
                    canonPrefab.transform.localEulerAngles += new Vector3(Time.deltaTime * 10, 0, 0);
                }
            }
            else if (Input.GetKey(KeyCode.E))
            {
                if (canonPrefab.transform.localEulerAngles.x is > 270f or < 90f)
                {
                    canonPrefab.transform.localEulerAngles += new Vector3(Time.deltaTime * -10, 0, 0);
                }
            }
        }
    }
}
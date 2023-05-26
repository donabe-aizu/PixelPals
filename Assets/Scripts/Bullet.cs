using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(BulletLife());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Enemy")) return;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            KillEnemy(collision.gameObject);
        }
                
        DestroyBullet();
    }

    void KillEnemy(GameObject enemy)
    {
        // ステータス更新
        Debug.Log("倒した");
            
        Destroy(enemy);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        // 爆発処理とか入れたい
        Debug.Log("爆発");
            
        Destroy(this.gameObject);
    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
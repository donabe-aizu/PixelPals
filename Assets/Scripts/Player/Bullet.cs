using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private AudioClip explodeBulletSE;

    private AudioSource _source;

    public event Action OnKillEnemy;

    private void Start()
    {
        StartCoroutine(BulletLife());
        _source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ExplodeBullet();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            KillEnemy(collision.gameObject);
            ExplodeBullet();
        }
        else if (collision.gameObject.CompareTag("EnemyBase"))
        {
            DamageEnemyBase(collision.gameObject);
            ExplodeBullet();
        }
    }

    private void KillEnemy(GameObject enemy)
    {
        OnKillEnemy.Invoke();
            
        Destroy(enemy);
    }

    private void DamageEnemyBase(GameObject enemyBase)
    {
        enemyBase.GetComponent<EnemyBaseStatus>().Damage();
    }

    private void ExplodeBullet()
    {
        // 爆発処理
        Instantiate(explosionPrefab,this.transform.position,Quaternion.identity).AddComponent<DestroyObject>().DestroyObjectByTime(3f);
        
        // 爆発SE処理
        StartCoroutine(PlayOneShotAndDestroy(explodeBulletSE));
    }
    
    //音楽を鳴らし、鳴り終わったらオブジェクトを破棄するコルーチン
    IEnumerator PlayOneShotAndDestroy(AudioClip audioClip)
    {
        //音楽を鳴らす
        _source.PlayOneShot(audioClip);

        //終了まで待機
        yield return new WaitWhile(() => _source.isPlaying);
        
        Destroy(this.gameObject);
    }

    private IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
using System;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private GameObject enemy;

    [SerializeField] private float respawnDuration;

    [SerializeField] private int limitRespawnCount;

    //　今何人の敵を出現させたか（総数）
    private int respawnedEnemyCount;

    //　待ち時間計測フィールド
    private float respawnElapsedTime;

    // Use this for initialization
    private void Start()
    {
        respawnedEnemyCount = 0;
        respawnElapsedTime = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (respawnedEnemyCount >= limitRespawnCount) return;

        respawnElapsedTime += Time.deltaTime;

        //　経過時間が経ったら
        if (respawnElapsedTime > respawnDuration)
        {
            respawnElapsedTime = 0f;

            RespawnEnemy();
        }
    }

    //　敵出現メソッド
    private void RespawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.Euler(0f, 0f, 0f))
            .GetComponent<EnemyMove>().targetObject = gameManager.Player;
        respawnedEnemyCount++;
        respawnElapsedTime = 0f;
    }
}
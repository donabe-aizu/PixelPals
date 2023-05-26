using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    
    [SerializeField] float respawnDuration;
    
    [SerializeField] int limitRespawnCount;
    
    //　今何人の敵を出現させたか（総数）
    private int respawnedEnemyCount;
    
    //　待ち時間計測フィールド
    private float respawnElapsedTime;
 
    // Use this for initialization
    void Start () {
        respawnedEnemyCount = 0;
        respawnElapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnedEnemyCount >= limitRespawnCount) {
            return;
        }
        
        respawnElapsedTime += Time.deltaTime;
 
        //　経過時間が経ったら
        if (respawnElapsedTime > respawnDuration) {
            respawnElapsedTime = 0f;
 
            RespawnEnemy();
        } 
    }
    
    //　敵出現メソッド
    void RespawnEnemy() {
        GameObject.Instantiate(enemy, transform.position, Quaternion.Euler (0f, 0f, 0f));
        respawnedEnemyCount++;
        respawnElapsedTime = 0f;
    }
}

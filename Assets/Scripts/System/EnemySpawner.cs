using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2f;

    [Header("Y Range")]
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 3f;

    [Header("X Position")]
    [SerializeField] private float spawnX = 10f;

    private void OnEnable()
    {
        //Bossウェーブ開始イベント
        WaveManager.OnBossStart += StopSpawn;
    }

    private void OnDisable()
    {
        //Bossウェーブ開始イベント
        WaveManager.OnBossStart -= StopSpawn;
    }

    //private void Start()
    //{
    //    InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    //}

    public void SpawnEnemy()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0f);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    void StopSpawn()
    {
        CancelInvoke(nameof(SpawnEnemy));
    }

    /// <summary>
    /// 縦フォーメーション敵生成
    /// </summary>
    public void SpawnVerticalFormation()
    {
        for (int i = 0; i < 3; i++)
        {
            float y = 2 - i * 1.5f;

            Vector3 pos = new Vector3(spawnX, y, 0);

            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }

    /// <summary>
    /// ジグザグフォーメーション敵生成
    /// </summary>
    public void SpawnZigzagFormation()
    {
        float y = Random.Range(minY, maxY);

        Instantiate(enemyPrefab, new Vector3(spawnX, y, 0), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(spawnX + 1.5f, y + 1, 0), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(spawnX + 3f, y, 0), Quaternion.identity);
    }
}

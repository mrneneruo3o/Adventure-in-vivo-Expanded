using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject bossPrefab;

    private void OnEnable()
    {
        //Bossウェーブ開始イベント
        WaveManager.OnBossStart += BossSpawn;
    }

    private void OnDisable()
    {
        //Bossウェーブ開始イベント
        WaveManager.OnBossStart -= BossSpawn;
    }

    private void BossSpawn()
    {
        Vector3 spawnPos = new Vector3(5f, 0f, 0f);
        Instantiate(bossPrefab, spawnPos, Quaternion.identity);
    }
}

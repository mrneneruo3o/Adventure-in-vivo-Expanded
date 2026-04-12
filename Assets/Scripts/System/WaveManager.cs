using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int enemyToBoss = 10;

    private int currentCount = 0;

    /// <summary>
    /// BOSSWAVEを知らせるイベント　ScoreManagerへ
    /// </summary>
    public static event Action OnBossStart;


    private void OnEnable()
    {
        Enemy_ZAKO.OnEnemyDead += CountEnemy;
    }

    private void OnDisable()
    {
        Enemy_ZAKO.OnEnemyDead -= CountEnemy;
    }

    void CountEnemy()
    {
        currentCount++;

        if (currentCount >= enemyToBoss)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        OnBossStart?.Invoke();
    }
}

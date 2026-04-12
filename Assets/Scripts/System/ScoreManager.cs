using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

/// <summary>
/// スコアの管理をする。
/// スコアの値をもつ。UIに連絡する。
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int enemyDestroyScore = 100;
    [SerializeField] private int bulletMissShotScore = -10;

    private int currentScore;

    public static event Action<int> OnScoreChanged;

    private void Awake()
    {
        currentScore = 0;
    }

    void Start()
    {
        OnScoreChanged?.Invoke(currentScore);
    }

    private void OnEnable()
    {
        Enemy_ZAKO.enemyDestroyScore += AddenemyDestroyScore;
        Bullet.OnBulletMissShot += AddbulletMissShot;
    }

    private void OnDisable()
    {
        Enemy_ZAKO.enemyDestroyScore -= AddenemyDestroyScore;
        Bullet.OnBulletMissShot -= AddbulletMissShot;
    }

    void AddenemyDestroyScore()
    {
        AddScore(enemyDestroyScore);
    }

    void AddbulletMissShot()
    {
        AddScore(bulletMissShotScore);
    }

    void AddScore(int amount)
    {
        currentScore += amount;
        OnScoreChanged?.Invoke(currentScore);
    }
}

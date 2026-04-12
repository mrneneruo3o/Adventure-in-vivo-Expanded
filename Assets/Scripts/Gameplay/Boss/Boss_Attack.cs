using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// É{ÉXÇÃçUåÇÇêßå‰Ç∑ÇÈ
/// </summary>

public class Boss_Attack : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        var pos = transform.position;
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }


}

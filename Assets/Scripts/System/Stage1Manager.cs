using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ1の進行全体を制御する
/// </summary>
public class Stage1Manager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform bossSpawnPoint;

    //会話イベントが終わったかフラグ
    private bool dialogueFinished = false;
    private bool bossDead = false;

    void Start()
    {
        StartCoroutine(StageRoutine());
    }

    IEnumerator StageRoutine()
    {
        // 会話イベント
        yield return StartCoroutine(Dialogue());

        yield return StartCoroutine(Wave1());

        yield return StartCoroutine(Wave2());

        yield return StartCoroutine(Wave3());

        ShowWarning();

        SpawnBoss();

        yield return new WaitUntil(() => bossDead);

        ShowClear();
    }

    IEnumerator Dialogue()
    {
        dialogueFinished = false;

        GameEvents.StartDialogue();

        yield return new WaitUntil(() => dialogueFinished);
    }


    IEnumerator Wave1()
    {
        for (int i = 0; i < 3; i++)
        {
            enemySpawner.SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator Wave2()
    {
        for (int i = 0; i < 3; i++)
        {
            enemySpawner.SpawnVerticalFormation();
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator Wave3()
    {
        for (int i = 0; i < 2; i++)
        {
            enemySpawner.SpawnZigzagFormation();
            yield return new WaitForSeconds(2f);
        }
    }

    void OnEnable()
    {
        GameEvents.OnDialogueEnd += HandleDialogueEnd;
    }

    void OnDisable()
    {
        GameEvents.OnDialogueEnd -= HandleDialogueEnd;
    }

    void HandleDialogueEnd()
    {
        dialogueFinished = true;
    }


    void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
    }

    void ShowWarning()
    {
        Debug.Log("WARNING!");
    }

    void ShowClear()
    {
        Debug.Log("CLEAR!");
        Time.timeScale = 0f;
    }

    // ボス死亡イベントを受け取る
    public void OnBossDead()
    {
        bossDead = true;
    }

}

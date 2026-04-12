using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ゲームクリア状態の管理と遷移判断
/// UIの見た目制御はしない
/// ボタンの処理はもたない

public class GameClearManager : MonoBehaviour
{

    [SerializeField] private GameObject gameClearPanel;

    private void OnEnable()
    {
        GameManager.OnGameClear += ShowGameClear;
    }

    private void OnDisable()
    {
        GameManager.OnGameClear -= ShowGameClear;
    }

    private void ShowGameClear()
    {
        gameClearPanel.SetActive(true);
    }
}

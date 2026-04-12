using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームオーバー状態の管理と遷移判断
/// UIの見た目制御はしない
/// ボタンの処理はもたない
/// </summary>

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable()
    {
        GameManager.OnGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

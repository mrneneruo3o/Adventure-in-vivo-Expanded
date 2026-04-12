using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体の進行を管理するクラス。
/// イベントを受け取り、それを他クラスへ伝達するだけ。
/// </summary>

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// シングルトンパターン
    /// </summary>
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    /// <summary>
    /// ゲームオーバーを通知するイベント
    /// </summary>
    public static event Action OnGameOver;

    /// <summary>
    /// ゲームクリアを通知するイベント
    /// </summary>
    public static event Action OnGameClear;


    private void OnEnable()
    {
        //タイトル画面からステージ選択へ移動オンのイベント
        GameEvents.changeSceneStageSelect += ChangeScene;


        //プレイヤーのライフが0になったらゲームオーバー
        PlayerLifeStatus.OnLifeZero += GameOver;
        //出血量が0になったらゲームオーバー　（本当はゲージ満タン許容量を超えたらゲームオーバーに修正する）
        BleedStatus.OnBleedZero += GameOver;
        //ボスのHPが0になったらゲームクリアー
        GameEvents.OnBossDead += GameClear;
    }

    private void OnDisable()
    {
        GameEvents.changeSceneStageSelect -= ChangeScene;

        PlayerLifeStatus.OnLifeZero -= GameOver;
        BleedStatus.OnBleedZero -= GameOver;
        GameEvents.OnBossDead += GameClear;
    }

    void GameOver()
    {
        //ゲームを止める
        Time.timeScale = 0f;
        OnGameOver?.Invoke();
    }

    void GameClear()
    {
        //ゲームを止める
        Time.timeScale = 0f;
        OnGameClear?.Invoke();
    }

    void ChangeScene(string changeScene)
    {
        switch (changeScene)
        {
            case "StageSlect":
                SceneManager.LoadScene("StageSelect");
                break;
            default:
                SceneManager.LoadScene("Title");
                break;


        }
    }
}

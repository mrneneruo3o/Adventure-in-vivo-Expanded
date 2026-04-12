using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// イベント管理クラス
/// </summary>
public static class GameEvents
{
    /// <summary>
    /// ステージ選択画面へ遷移イベント　GameManagerへ
    /// 引数　遷移したいシーン名　ステージセレクト
    /// </summary>
    public static event Action<string> changeSceneStageSelect;

    public static void SceneStageSelect(string sceneName)
    {
        changeSceneStageSelect?.Invoke(sceneName);
    }



    #region Bossイベント
    /// <summary>
    /// イベント　ステージ1の会話イベント開始を通知
    /// </summary>
    public static event Action OnStartDialogue;

    public static void StartDialogue()
    {
        OnStartDialogue?.Invoke();
    }

    /// <summary>
    /// イベント　ステージ1の会話イベント終了を通知
    /// </summary>
    public static event Action OnDialogueEnd;

    public static void DialogueEnd()
    {
        OnDialogueEnd?.Invoke();
    }
    #endregion}



    #region Bossイベント
    /// <summary>
    /// イベント　GameManagerへBossが死んだことを通知
    /// </summary>
    public static event Action OnBossDead;
    
    public static void BossDead()
    {
       OnBossDead?.Invoke();
    }
  
    #endregion}
}
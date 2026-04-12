using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 プレイヤー状態親クラス：PlayerStateBase 
 */
public class PlayerDamageState : PlayerStateBase
{
    float timer;

    public PlayerDamageState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        timer = 1.5f; // 点滅時間
        player.StartBlink(); // 見た目処理開始
    }

    public override void Update()
    {
        timer -= UnityEngine.Time.deltaTime;

        if (timer <= 0f)
        {
            player.ChangeState(new PlayerNormalState(player));
        }
    }

    public override void Exit()
    {
        player.StopBlink(); // 点滅終了
    }
}


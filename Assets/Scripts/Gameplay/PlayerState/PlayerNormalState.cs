using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 プレイヤー状態親クラス：PlayerStateBase 
 */
public class PlayerNormalState : PlayerStateBase
{
    public PlayerNormalState(PlayerController player) : base(player) { }

    public override void Update()
    {
        player.HandleMovement(); // ← 移動処理をPlayerControllerに任せる
    }
}

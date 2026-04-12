using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 
/// </summary>
public abstract class PlayerStateBase
{
    //「このステートは、このプレイヤーを操作しますよ」って覚えておくための変数　フィールド
    //protect このクラス+子クラスが使える　publicやprivateも可
    //PlayerControllerをplayerという変数に入れて操作します
    [Tooltip("Playerステートクラスが操作する対象：PlayerController")]
    protected PlayerController player;

    //コンストラクタ　newされたときに実行される
    //「外から渡されたプレイヤーを、このステートの中に保存してね」
    public PlayerStateBase(PlayerController player)
    {
        this.player = player;
    }

    //virttualを入れることで子クラスが上書きできる
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

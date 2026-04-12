using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;  //イベントを使うとき必須

/// <summary>
/// プレイヤーの動きを制御する
/// 
/// </summary>
/// 
public class PlayerController : MonoBehaviour
{
    //変数
    [Header("動くスピード")]
    [SerializeField] private int moveSpeed = 4;
    public static event Action OnHitEnemy;　　//イベント
    PlayerStateBase currentState;
    [SerializeField] private PlayerImage playerImage; // 追加（Inspectorで設定）


    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new PlayerNormalState(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    //Collider2Dが設定されたオブジェクトと衝突したときに何が起きるか
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //今ダメージを受けられるか確認　プレイヤーダメージステートなら処理を抜ける
            if (currentState is PlayerDamageState) return;

            ChangeState(new PlayerDamageState(this));
            OnHitEnemy?.Invoke(); // 既存イベントはそのまま使ってOK
        }

    }

    public void StartBlink()
    {
        playerImage.StartBlink();
    }

    public void StopBlink()
    {
        playerImage.StopBlink();
    }


    //ステート切替メソッド追加
    public void ChangeState(PlayerStateBase newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }
    public void HandleMovement()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var moveDirection = new Vector2(x, y).normalized;

        var pos = transform.position;
        pos += (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -8.4f, 8.4f);
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);

        transform.position = pos;
    }

}

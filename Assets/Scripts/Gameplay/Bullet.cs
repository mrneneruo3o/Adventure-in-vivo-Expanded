using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  //イベントを使うとき必須

/// <summary>
/// 役割：プレイヤーが撃つ弾の動きを制御する
/// 
/// </summary>
public class Bullet : MonoBehaviour
{
    //変数
    [Header("動くスピード")]
    [SerializeField] private int moveSpeed = 10;

    //イベント
    /// <summary>
    /// 弾を体に当ててしまったときのBleedゲージ変更のイベント
    /// </summary>
    public static event Action OnHitBody;
    /// <summary>
    /// 弾を体に当ててしまったときのペナルティイベント　スコア減少
    /// </summary>
    public static event Action OnBulletMissShot;

    // Update is called once per frame
    void Update()
    {
        //右へ進む
        Move(Vector2.right);

        //枠の外に出たら消える
        if (transform.position.x >= 20.0f)
        {
            Destroy(this.gameObject);
        }

    }

    private void Move(Vector3 moveDirection)
    {
        //ザコ敵の座標を取得
        var pos = transform.position;

        //現在の座標に移動速度×移動方向（ベクトル）をくわえる
        pos += moveDirection * moveSpeed * Time.deltaTime;

        //ザコ敵の現在地の更新
        transform.position = pos;
    }

    //Collider2Dが設定されたオブジェクトと衝突したときに何が起きるか
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 相手がEnemyタグかどうか
        if (other.CompareTag("Enemy"))
        {
            // 弾を消す
            Destroy(gameObject);
        }
        else if (other.CompareTag("Boss"))
        {
            // 弾を消す
            Destroy(gameObject);
        }

    }



}

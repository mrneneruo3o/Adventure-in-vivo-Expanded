using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
/// <summary>
/// ザコ敵の動きを制御する
/// 
/// </summary>

public class Enemy_ZAKO : MonoBehaviour
{
    //変数
    [Header("動くスピード")]
    [SerializeField] private int moveSpeed = 3;

    /// <summary>
    /// スコアを変更するイベント　ScoreManagerへ
    /// </summary>
    public static event Action enemyDestroyScore;

    /// <summary>
    /// ザコ敵が死んだことを知らせるイベント　WaveManagerへ
    /// </summary>
    public static event Action OnEnemyDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //左へ進む
        Move(Vector2.left);

        //枠の外に出たら消える
        if (transform.position.x <= -20.0f) {
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
        //Bulletタグに当たったら消える
        if (other.CompareTag("Bullet"))
        {
            //Scoreに連携
            enemyDestroyScore?.Invoke();

            //死んだことを連携
            OnEnemyDead?.Invoke();

            Destroy(this.gameObject);
        }

        //Playerというレイヤーに当たったら消える

        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        
    }

}

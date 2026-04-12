using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 役割：出血量の管理と増減処理
///やらないこと
/// -ゲージの表示
///- UI操作
///- 効果音再生
/// </summary>
public class BleedStatus : MonoBehaviour
{
    //変数
    [Header("出血許容量")]
    [SerializeField] private int maxBleed = 10;
    public int MaxBleed => maxBleed;　//プロパティ化

    private int currentBleed;
    public int CurrentBleed => currentBleed; //プロパティ化
    private int Henkaryo_bleed = 0; //bleedchangeに渡す変化量

    //イベント
    public static event Action<int> OnBleedChanged;
    public static event Action OnBleedZero;

    void Awake()
    {
        currentBleed = maxBleed;
    }

    //テスト20260205
    void Update()
    {
        // Hキーで出血回復テスト
        if (Input.GetKeyDown(KeyCode.H))
        {
            HealBleed(2); // 好きな回復量
        }
    }

    private void OnEnable()
    {
        Bullet.OnHitBody += Damage;
    }

    private void OnDisable()
    {
        Bullet.OnHitBody -= Damage;
    }

    void Damage()
    {
        currentBleed--;

        //出血量がマイナスにいっても0になるようにする
        if (currentBleed < 0)
            currentBleed = 0;

        //ゲージを変更
        OnBleedChanged?.Invoke(1);


        if (currentBleed == 0)
            OnBleedZero?.Invoke();
    }

    //出血ゲージを回復する
    public void HealBleed(int amount)
    {
        //現在のBleedHPと回復量でmaxを超える場合は、maxから現在値を引いた値
        if (currentBleed + amount > maxBleed)
        {
            Henkaryo_bleed = maxBleed - currentBleed;
        }
        else
        {
            //現在のBleedHPと回復量でmaxを超えない場合は、回復量でOK
            Henkaryo_bleed = amount;
        }
        
        //現在のHPに足す（回復）
        currentBleed += amount;

        // 最大値を超えないように制限
        currentBleed = Mathf.Clamp(currentBleed, 0, maxBleed);

        OnBleedChanged?.Invoke(-1* Henkaryo_bleed);
        //BleedGuageControllerへ
        //BleedPanelControllerへ

    }

}

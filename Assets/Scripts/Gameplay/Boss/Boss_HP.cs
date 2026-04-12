using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_HP : MonoBehaviour
{
    #region 変数
    [Header("BOSSのHP")]
    [SerializeField] private int bossHP = 2;
    private int bossCurrentHp = 0;
    #endregion

 
    private void Awake()
    {
        //現在のHPの初期化。設定したボスのHPを代入。
        bossCurrentHp = bossHP;

    }

    private void OnEnable()
    {
        Boss_MoveController.bossDamage += bossHpsubtract;
    }

    private void OnDisable()
    {
        Boss_MoveController.bossDamage -= bossHpsubtract;
    }

    private void bossHpsubtract()
    {
        bossCurrentHp--;

        if (bossCurrentHp == 0) 
        {
            GameEvents.BossDead();
        }
    }
}

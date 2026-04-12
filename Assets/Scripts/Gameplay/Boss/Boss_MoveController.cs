using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスの動きを制御する
/// </summary>

public class Boss_MoveController : MonoBehaviour
{

    /// <summary>
    /// HPを変更するイベント　Boss_HPへ
    /// </summary>
    public static event Action bossDamage;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            //Boss_HPに連携
            bossDamage?.Invoke();
        }
    }
}

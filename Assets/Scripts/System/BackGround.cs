using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景をスクロールさせる
/// 背景本体にアタッチ
/// </summary>
public class BackGround : MonoBehaviour
{
    [Header("scrollspeed")]
    public float ScrollSpeed;

    //背景を配置する間隔
    public float bgInterval;

    private void Update()
    {
        //左に少しずつ移動させる
        var nextPosX = transform.position.x - (ScrollSpeed * Time.deltaTime);
        transform.position = new Vector2 (nextPosX, 0);

        //画面外の左側まできたら右側に移動させる
        if(transform.position.x <= -bgInterval) 
        {
            transform.position = new Vector2(bgInterval, 0);
        }
    }
}

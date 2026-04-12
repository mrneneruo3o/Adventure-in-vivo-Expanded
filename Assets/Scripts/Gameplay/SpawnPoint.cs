using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 役割：弾プレハブを生成する
///やらないこと
/// -
///-
///-
/// </summary>

public class SpawnPoint : MonoBehaviour
{
    //変数
    [Header("弾プレハブ")]
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spaceキーが押されたらBulletプレハブが出現する
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            //オブジェクトを生成する(オブジェクト, 位置：今回はSpawnPointがある位置, 回転の有無：なし)
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }
    }
}

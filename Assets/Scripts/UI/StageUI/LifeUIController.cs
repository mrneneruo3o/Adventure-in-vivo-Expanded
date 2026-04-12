using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーのライフゲージを制御する。
/// 
/// </summary>
public class LifeUIController : MonoBehaviour
{
    //変数
    public GameObject[] lifeArray = new GameObject[3];

    private void OnEnable()
    {
        PlayerLifeStatus.OnLifeChanged += LifeMainasu;
    }

    private void OnDisable()
    {
        PlayerLifeStatus.OnLifeChanged -= LifeMainasu;
    }



    //Playerが敵に当たったら、ライフを減らす処理を呼ぶ
    void LifeMainasu(int Player_HP)
    {
        if (Player_HP >= 0 && Player_HP < lifeArray.Length)
        {
            lifeArray[Player_HP].SetActive(false);
        }
    }
}

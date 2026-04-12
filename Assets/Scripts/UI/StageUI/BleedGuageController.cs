using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ゲージUIをコントロールするクラス。
/// ゲージを制御する以外はやらない。
/// </summary>
public class BleedGuageController : MonoBehaviour
{
    // Bleedゲージ（表面の常に見える部分）
    [SerializeField] private GameObject gauge;
    // 猶予ゲージ（体力が減ったとき一瞬見える部分）
    [SerializeField] private GameObject graceGauge;

    // 最大HP
    // [SerializeField] private int HP;
    [SerializeField] private BleedStatus bleedManager;

    // BleedGuageScaleあたりの幅
    private float BleedGuageScale = 0f;

    // Bleedゲージが減った後裏ゲージが減るまでの待機時間
    private float waitingTime = 0.5f;

    private void OnEnable()
    {
        BleedStatus.OnBleedChanged += BeInjured;
    }

    private void OnDisable()
    {
        BleedStatus.OnBleedChanged -= BeInjured;
    }

    void Awake()
    {
        // スプライトの幅を最大HPで割ってBleedGuageScaleあたりの幅を”BleedGuageScale”に入れておく
        BleedGuageScale = gauge.GetComponent<RectTransform>().sizeDelta.x / bleedManager.MaxBleed;
    }

    // 攻撃力をそれぞれのボタンで設定
    public void BeInjured(int atacck)
    {
        // 攻撃力と体力1あたりの幅の積が実際にBleedゲージから減らす幅
        float damege = BleedGuageScale * atacck;

        // 減らす幅を設定してコルーチン”damegeEm”を呼び出し
        StartCoroutine(damegeEm(damege));
    }

    // Bleedゲージを減らすコルーチン
    IEnumerator damegeEm(float damege)
    {
        // Bleedゲージの幅と高さをVector2で取り出す(Width,Height)
        Vector2 nowsafes = gauge.GetComponent<RectTransform>().sizeDelta;
        // Bleedゲージの幅からダメージ分の幅を引く
        nowsafes.x -= damege;
        // Bleedゲージに計算済みのVector2を設定する
        gauge.GetComponent<RectTransform>().sizeDelta = nowsafes;

        // ”waitingTime”秒待つ
        yield return new WaitForSeconds(waitingTime);
        // 猶予ゲージに計算済みのVector2を設定する
        graceGauge.GetComponent<RectTransform>().sizeDelta = nowsafes;
    }
}

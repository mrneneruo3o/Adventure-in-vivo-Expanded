using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 出血量に応じた演出パネルを制御するクラス。
/// 
/// </summary>

public class BleedPanelController : MonoBehaviour
{
    [Header("マネージャー")]
    [SerializeField] private BleedStatus bleedManager;
    [Header("表示する画像")]
    [SerializeField] private GameObject bloodImage; // 血痕画像
    [Header("表示タイミング")]
    [SerializeField] private int showThreshold = 2; // これ以下になったら表示


    private void OnEnable()
    {
        BleedStatus.OnBleedChanged += ChangeBleedImage;
    }

    private void OnDisable()
    {
        BleedStatus.OnBleedChanged -= ChangeBleedImage;
    }

    void ChangeBleedImage(int A)
    {
        // 出血が増えてきたら表示
        if (bleedManager.CurrentBleed <= bleedManager.MaxBleed / showThreshold)
        {
            bloodImage.SetActive(true);
        }
        else
        {
            bloodImage.SetActive(false);
        }
    }
}

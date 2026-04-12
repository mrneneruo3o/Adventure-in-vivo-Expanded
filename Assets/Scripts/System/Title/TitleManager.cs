using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class TitleManager : MonoBehaviour
{
    /// <summary>
    /// 遷移するステージ選択シーン名
    /// </summary>
    private string changeScene = "StageSlect";

    [SerializeField] private Graphic TitleText; 
    [SerializeField] private float interval = 0.8f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameEvents.SceneStageSelect(changeScene);
        }
    }
    void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            TitleText.enabled = !TitleText.enabled;
            yield return new WaitForSeconds(interval);
        }
    }
}

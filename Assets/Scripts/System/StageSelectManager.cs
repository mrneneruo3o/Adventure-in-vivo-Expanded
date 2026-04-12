using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    [Header("StageSelectMenu")]
    [SerializeField] private GameObject StageSelectMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.StartDialogue();
    }

    private void OnEnable()
    {
        GameEvents.OnDialogueEnd += ShowStageSelect;
    }

    private void OnDisable()
    {
        GameEvents.OnDialogueEnd -= ShowStageSelect;
    }

    //会話が終わったらステージ選択画面を表示する
    private void ShowStageSelect()
    {
        StageSelectMenu.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/// <summary>
/// 会話イベントの動きを管理
/// </summary>
public class DialogueManager : MonoBehaviour
{
    //gitのテストぽよ
    [SerializeField] GameObject DialoguePanel;
    [SerializeField] Image faceImage;
    [SerializeField] Text nameText;
    [SerializeField] Text messageText;

    [SerializeField] DialogueData dialogueData;

    int index = 0;

    private void OnEnable()
    {
        //Stage1会話イベント開始イベント
        GameEvents.OnStartDialogue += StartDialogue;
    }

    private void OnDisable()
    {
        //Stage1会話イベント
        GameEvents.OnStartDialogue -= StartDialogue;
    }


    public void StartDialogue()
    {
        DialoguePanel.SetActive(true);
        ShowLine();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextLine();
        }
    }

    void ShowLine()
    {
        var line = dialogueData.lines[index];

        faceImage.sprite = line.face;
        nameText.text = line.characterName;
        messageText.text = line.message;
    }

    void NextLine()
    {
        index++;

        if (index >= dialogueData.lines.Count)
        {
            EndDialogue();
            return;
        }

        ShowLine();
    }

    void EndDialogue()
    {
        DialoguePanel.SetActive(false);

        GameEvents.DialogueEnd();
    }
}

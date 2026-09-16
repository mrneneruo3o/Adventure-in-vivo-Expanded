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
    //会話パネル
    [SerializeField] GameObject DialoguePanel;
    [SerializeField] Image faceImage;
    [SerializeField] Text nameText;
    [SerializeField] Text messageText;

    //会話データ
    [Header("DialogueData")]
    [SerializeField] DialogueData dialogueData;

    //タイプライター風演出
    [SerializeField] float typingSpeed = 0.05f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip typingSE;

    bool isTyping = false;
    Coroutine typingCoroutine;

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
        index = 0;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        isTyping = false;

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
        //messageText.text = line.message;

        // 途中のコルーチンがあれば止める
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeText(line.message));
    }

    void NextLine()
    {
        //Debug.Log("NextLine呼ばれた"); //テスト

        // タイピング中なら全文表示して終了
        if (isTyping)
        {
            Debug.Log("タイピング中にスキップされた");　//テスト

            StopCoroutine(typingCoroutine);
            messageText.text = dialogueData.lines[index].message;
            isTyping = false;
            return;
        }

        index++;

        if (index >= dialogueData.lines.Count)
        {
            EndDialogue();
            return;
        }

        ShowLine();
    }

    //タイプライター風演出コルーチン
    IEnumerator TypeText(string message)
    {
        isTyping = true;
        messageText.text = "";

        int count = 0;

        foreach (char c in message)
        {
            messageText.text += c;
            count++;

            // 2文字ごとにSE
            if (count % 2 == 0)
            {
                if (typingSE != null)
                {
                    audioSource.PlayOneShot(typingSE);
                }
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        DialoguePanel.SetActive(false);

        GameEvents.DialogueEnd();
    }
}

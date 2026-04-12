using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 会話用データを作成できるもとを作る
/// クラスにScriptableObjectを継承することで、UnityのAssetとして保存できる
/// </summary>
[CreateAssetMenu(menuName = "Game/Dialogue")]
public class DialogueData : ScriptableObject
{
    public List<DialogueLine> lines;
}

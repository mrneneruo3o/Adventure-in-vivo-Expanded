using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‰ï˜b—p‚ÌScriptableObject‚ğì¬‚·‚é
/// </summary>

//Unity‚ÌInspecter‚É•\¦‚³‚ê‚é
[System.Serializable]
public class DialogueLine
{
    public string characterName;

    public Sprite face;

    [TextArea]
    public string message;
}

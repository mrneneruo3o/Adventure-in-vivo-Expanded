using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImage : MonoBehaviour
{
    //移動スピードと点滅の間隔
    [SerializeField] float speed, flashInterval;
    //点滅させるときのループカウント
    [SerializeField] int loopCount;
    //点滅させるためのSpriteRenderer
    SpriteRenderer sp;
    Coroutine blinkRoutine;


    private void Awake()
    {
        //SpriteRenderer格納
        sp = GetComponent<SpriteRenderer>();
    }

    public void StartBlink()
    {
        if (blinkRoutine != null)
            StopCoroutine(blinkRoutine);

        blinkRoutine = StartCoroutine(BlinkCoroutine());
    }

    public void StopBlink()
    {
        if (blinkRoutine != null)
            StopCoroutine(blinkRoutine);

        sp.enabled = true;
    }

    IEnumerator BlinkCoroutine()
    {
        for (int i = 0; i < loopCount; i++)
        {
            sp.enabled = false;
            yield return new WaitForSeconds(flashInterval);
            sp.enabled = true;
            yield return new WaitForSeconds(flashInterval);
        }
    }

}

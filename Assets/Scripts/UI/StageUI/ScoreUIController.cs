using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ScoreUIÇçXêVÇ∑ÇÈÅB
/// </summary>
public class ScoreUIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public TMP_Text scoreText;

    private void Awake()
    {
        scoreManager = this;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}

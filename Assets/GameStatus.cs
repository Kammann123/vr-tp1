using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    private int score;

    public int Score {
        get { return this.score; }
    }

    public void AddScore(int score)
    {
        this.score += score;
        this.UpdateScoreText();
    }

    public void RemoveScore(int score)
    {
        this.score -=score;
        if (this.score < 0)
        {
            this.score = 0;
        }
        this.UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        var scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = this.score.ToString();
    }
}
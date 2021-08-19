using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public TextMesh text;

    public int Score {
        get { return this.score; }
        set {
            this.score = value >= 0 ? value : 0;
            this.text.text = "Score " + this.score.ToString();
        }
    }    

    public void AddScore(int value)
    {
        this.Score += value;
    }

    public void RemoveScore(int value)
    {
        this.Score -= value;
    }
}
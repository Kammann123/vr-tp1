using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Private field containing the player's score
    private int _score;

    // Public property to write or read the player's score
    public int Score {
        get { return this._score; }
        set {
            this._score = value >= 0 ? value : 0;
            Text scoreText = this.GetComponent<Text>();
            scoreText.text = this._score.ToString();
        }
    }    

    // Add the given score to the player's current score
    public void AddScore(int score)
    {
        this.Score += score;
    }

    // Remove the given score to the player's current score
    public void RemoveScore(int score)
    {
        this.Score -= score;
    }
}
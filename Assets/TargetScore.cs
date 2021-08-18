using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public int reward;

    void OnTriggerEnter(Collider collider)
    {
        // Search throughout the game's objects for the Score tagged object
        // which contains the ScoreManager script used to keep the player's 
        // progress and score
        ScoreManager score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        score.AddScore(this.reward);
    }
}

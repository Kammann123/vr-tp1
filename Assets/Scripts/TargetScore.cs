using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public int reward;

    void OnTriggerEnter(Collider collider)
    {
        TargetActivation activation = GetComponent<TargetActivation>();
        if (activation.Activated)
        {
            ScoreManager score = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>();
            score.AddScore(this.reward);
            activation.Deactivate();
        }
    }
}

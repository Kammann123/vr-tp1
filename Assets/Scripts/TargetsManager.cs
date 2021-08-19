using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsManager : MonoBehaviour
{
    public float period = 5;
    private float timer;
    private GameObject[] targets;
    private int chosen;

    void Start()
    {
        this.targets = GameObject.FindGameObjectsWithTag("Target");
        this.timer = this.period;
        this.chosen = -1;
    }

    void Update()
    {
        if (this.timer > 0)
        {
            this.timer -= Time.deltaTime;
        }
        else
        {
            this.RandomTargets();
            this.timer = this.period;
        }
    }

    void RandomTargets()
    {
        int randomChoice;

        // Randomly choose one target to be activated the next round
        System.Random random = new System.Random();
        do
        {
            randomChoice = random.Next(0, this.targets.Length);
        } while (randomChoice == this.chosen);
        this.chosen = randomChoice;

        // Deactivate all other targets
        foreach (GameObject target in this.targets)
        {
            target.GetComponent<TargetActivation>().Deactivate();
        }

        // Activate only the chosen
        this.targets[this.chosen].GetComponent<TargetActivation>().Activate();
    }
}

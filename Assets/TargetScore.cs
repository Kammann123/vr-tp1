using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public int price;
    private GameStatus game;

    void Start()
    {
        this.game = GameObject.FindGameObjectWithTag("Player").GetComponent<GameStatus>();
        this.price = 10;
    }

    void OnTriggerEnter(Collider collider)
    {
        game.AddScore(this.price);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private void Start()
    {
        score = 0;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    score += 1;
    //    CounterText.text = "Count : " + score;
    //}

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}

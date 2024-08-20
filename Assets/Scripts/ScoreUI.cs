using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText; // Reference to the Text component

    // Function to update the score on the canvas
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance

    private int score; // The score value

    private void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Function to increment the score
    public void IncrementScore(int value)
    {
        score += value;

        // Update the score on the canvas
        ScoreUI scoreUI = FindObjectOfType<ScoreUI>();
        if (scoreUI != null)
        {
            scoreUI.UpdateScore(score);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int score = 0;

    public void addScore(int score)
    {
        Debug.Log("Score: " + score);
        this.score += score;
    }

    public int getScore()
    {
        PlayerPrefs.SetInt("Score", score / 4);
        return score / 4;
    }
}

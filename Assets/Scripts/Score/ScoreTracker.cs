using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int score = 0;

    public void setScore(int score)
    {
        this.score = score;
    }

    public int getScore()
    {
        return score;
    }
}

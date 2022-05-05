using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text scoreText;
    public ScoreTracker scoreTracker;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = "Score:\n" + scoreTracker.getScore().ToString();
    }
}

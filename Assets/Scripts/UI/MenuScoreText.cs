using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScoreText : MonoBehaviour
{
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "You Scored:\n" + PlayerPrefs.GetInt("Score");
    }
}

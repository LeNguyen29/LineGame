using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.text = "High Score:\n" + PlayerPrefs.GetInt("HighScore", 0);
    }
}

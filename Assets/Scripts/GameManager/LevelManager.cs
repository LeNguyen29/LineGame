using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    public void ToGameOver()
    {
        Debug.Log("TO GAMEOVER");
        SceneManager.LoadScene("GameOverScene");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ToCredits()
    {
        Debug.Log("TO CREDITS");
        SceneManager.LoadScene("CreditScene");
    }

    public void ToInstruction()
    {
        Debug.Log("HOW 2 PLAY");
        SceneManager.LoadScene("InstructionScene");
    }
}

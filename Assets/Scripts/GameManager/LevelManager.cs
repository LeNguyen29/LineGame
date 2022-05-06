using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    public void ToCredits()
    {
        Debug.Log("TO CREDITS");
        //SceneManager.LoadScene("CreditScene");
    }

    public void ToInstruction()
    {
        Debug.Log("HOW 2 PLAY");
        //SceneManager.LoadScene("InstructionScene");
    }
}

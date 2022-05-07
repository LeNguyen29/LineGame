using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsDisplay : MonoBehaviour
{
    public Image[] ballsImage;

    private List<GameObject> ballList;

    private BallsDisplay INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void updateList(List<GameObject> ballList)
    {
        if (ballList != null)
        {
            for (int i = 0; i < ballsImage.Length; i++)
            {
                ballsImage[i].sprite = ballList[Random.Range(0, ballList.Count)].GetComponent<SpriteRenderer>().sprite;
            }
        }

    }
}

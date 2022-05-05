using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    public BallSpawner ballSpawner;
    public GridHandler gridHandler;

    public List<GameObject> ballList;

    public void setBallList()
    {
        ballList = ballSpawner.getBallList();
    }

    public void checkListBall()
    {
        foreach (var ball in ballList)
        {
            List<GameObject> sameColorList = new List<GameObject>();

            List<GameObject> temp = ball.GetComponent<BallRayShootOver>().checkLeft();
            foreach (var item in temp)
            {
                if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                    sameColorList.Add(item);
            }
            if (sameColorList.Count >= 3)
            {
                Debug.Log("We have enough left balls");
                popTheBalls(sameColorList);
                continue;
            }

            sameColorList.Clear();

            temp = ball.GetComponent<BallRayShootOver>().checkRight();
            foreach (var item in temp)
            {
                if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                    sameColorList.Add(item);
            }
            if (sameColorList.Count >= 3)
            {
                Debug.Log("We have enough right balls");
                popTheBalls(sameColorList);
                continue;
            }

            sameColorList.Clear();

            temp = ball.GetComponent<BallRayShootOver>().checkUp();
            foreach (var item in temp)
            {
                if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                    sameColorList.Add(item);
            }
            if (sameColorList.Count >= 3)
            {
                Debug.Log("We have enough up balls");
                popTheBalls(sameColorList);
                continue;
            }

            sameColorList.Clear();

            temp = ball.GetComponent<BallRayShootOver>().checkDown();
            foreach (var item in temp)
            {
                if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                    sameColorList.Add(item);
            }
            if (sameColorList.Count >= 3)
            {
                Debug.Log("We have enough down balls");
                popTheBalls(sameColorList);
                continue;
            }

            sameColorList.Clear();
        }
    }

    public void popTheBalls(List<GameObject> sameColorList)
    {
        foreach (var ball in sameColorList)
        {
            ball.SetActive(false);
        }
    }
}

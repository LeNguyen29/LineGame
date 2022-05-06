using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    public BallSpawner ballSpawner;
    public GridHandler gridHandler;

    public ScoreTracker scoreTracker;

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
            if (temp.Count > 1)
            {
                Vector3 tempPos = ball.transform.position;
                foreach (var item in temp)
                {
                    if (Mathf.FloorToInt(Vector3.Distance(tempPos, item.transform.position)) <= 4)
                    {
                        tempPos = item.transform.position;
                        if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                            sameColorList.Add(item);
                        else
                            break;
                    }
                    else
                        break;
                }
                if (sameColorList.Count >= 3)
                {
                    Debug.Log("We have enough left balls");
                    //ballList.Remove(ball);
                    scoreTracker.setScore(sameColorList.Count);
                    popTheBalls(sameColorList);
                    continue;
                }
            }

            sameColorList.Clear();

            temp = ball.GetComponent<BallRayShootOver>().checkRight();
            if (temp.Count > 1)
            {
                Vector3 tempPos = ball.transform.position;
                foreach (var item in temp)
                {
                    if (Mathf.FloorToInt(Vector3.Distance(tempPos, item.transform.position)) <= 4)
                    {
                        tempPos = item.transform.position;
                        if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                            sameColorList.Add(item);
                        else
                            break;
                    }
                    else
                        break;
                }
                if (sameColorList.Count >= 3)
                {
                    Debug.Log("We have enough left balls");
                    //ballList.Remove(ball);
                    scoreTracker.setScore(sameColorList.Count);
                    popTheBalls(sameColorList);
                    continue;
                }
            }

            sameColorList.Clear();

            temp = ball.GetComponent<BallRayShootOver>().checkUp();
            if (temp.Count > 1)
            {
                Vector3 tempPos = ball.transform.position;
                foreach (var item in temp)
                {
                    if (Mathf.FloorToInt(Vector3.Distance(tempPos, item.transform.position)) <= 4)
                    {
                        tempPos = item.transform.position;
                        if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                            sameColorList.Add(item);
                        else
                            break;
                    }
                    else
                        break;
                }
                if (sameColorList.Count >= 3)
                {
                    Debug.Log("We have enough left balls");
                    //ballList.Remove(ball);
                    scoreTracker.setScore(sameColorList.Count);
                    popTheBalls(sameColorList);
                    continue;
                }
            }

            sameColorList.Clear();

            temp = ball.GetComponent<BallRayShootOver>().checkDown();
            if (temp.Count > 1)
            {
                Vector3 tempPos = ball.transform.position;
                foreach (var item in temp)
                {
                    if (Mathf.FloorToInt(Vector3.Distance(tempPos, item.transform.position)) <= 4)
                    {
                        tempPos = item.transform.position;
                        if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                            sameColorList.Add(item);
                        else
                            break;
                    }
                    else
                        break;
                }
                if (sameColorList.Count >= 3)
                {
                    Debug.Log("We have enough left balls");
                    //ballList.Remove(ball);
                    scoreTracker.setScore(sameColorList.Count);
                    popTheBalls(sameColorList);
                    continue;
                }
            }

            sameColorList.Clear();
        }
    }

    public void popTheBalls(List<GameObject> sameColorList)
    {
        foreach (var ball in sameColorList)
        {
            ball.GetComponent<Ball>().explode();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    public BallSpawner ballSpawner;
    public BallAbility ballAbility;

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
                        if (item.GetComponent<Ball>().type == ball.GetComponent<Ball>().type)
                        {
                            if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                                sameColorList.Add(item);
                            else
                                break;
                        }
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
                    scoreTracker.addScore(sameColorList.Count);
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
                        if (item.GetComponent<Ball>().type == ball.GetComponent<Ball>().type)
                        {
                            if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                                sameColorList.Add(item);
                            else
                                break;
                        }
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
                    scoreTracker.addScore(sameColorList.Count);
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
                        if (item.GetComponent<Ball>().type == ball.GetComponent<Ball>().type)
                        {
                            if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                                sameColorList.Add(item);
                            else
                                break;
                        }
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
                    scoreTracker.addScore(sameColorList.Count);
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
                        if (item.GetComponent<Ball>().type == ball.GetComponent<Ball>().type)
                        {
                            if (item.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color)
                                sameColorList.Add(item);
                            else
                                break;
                        }
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
                    scoreTracker.addScore(sameColorList.Count);
                    popTheBalls(sameColorList);
                    continue;
                }
            }

            sameColorList.Clear();
        }
    }

    public void popTheBalls(List<GameObject> ballList)
    {
        foreach (var ball in ballList)
        {
            ball.GetComponent<Ball>().explode();
        }

        ballAbility.useAbility(ballList[0].GetComponent<Ball>().type);
    }
}

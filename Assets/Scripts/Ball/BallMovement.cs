using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector3 targetPosition;
    private List<Vector3> moveVectorList;

    private int index = 0;

    private bool canMove = false;

    private BallMovementBase ballMoveBase;

    void FixedUpdate()
    {
        if (moveVectorList != null && moveVectorList.Count > 0)
        {
            Debug.Log("Move Vector List count: " + moveVectorList.Count);
            Debug.Log("Moving to [" + index + "]: " + moveVectorList[index].ToString());

            canMove = true;
            ballMoveBase.reachTarget = false;

            targetPosition = moveVectorList[index];

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);

            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            Debug.Log($"Current Pos: {transform.position.ToString()} | Target Pos: {targetPosition.ToString()}");
            Debug.Log($"Distance to target {targetPosition.ToString()}: " + distanceToTarget);

            if (transform.position == targetPosition)
            {
                Debug.Log("Reached Position");

                index++;

                Debug.Log("Current move index: " + index);

                if (index >= moveVectorList.Count)
                {
                    index = 0;
                    stopMoving();
                    Debug.Log("Reset move index: " + index);
                }
            }
        }
    }

    public void stopMoving()
    {
        Debug.Log("Stop moving");
        ballMoveBase.reachTarget = true;
        Debug.Log("Reach: " + ballMoveBase.reachTarget);
        moveVectorList.Clear();
        canMove = false;
        Debug.Log("Move Vector List count reset: " + moveVectorList.Count);
    }

    public void setMove(bool value)
    {
        canMove = value;
        Debug.Log(canMove);
    }

    public void setBase(BallMovementBase ballMoveBase)
    {
        this.ballMoveBase = ballMoveBase;
    }

    public void setMoveVectorList(List<Vector3> moveVectorList)
    {
        Debug.Log("Setting move vector list");
        this.moveVectorList = moveVectorList;
        for (int i = 0; i < moveVectorList.Count; i++)
        {
            Debug.Log("Received Vector: " + moveVectorList[i].ToString());
        }
    }

    public void setMovePosition(Vector3 movePosition)
    {
        this.targetPosition = movePosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBallMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 targetPosition;

    private bool canMove = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (canMove)
        {
            if (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
            }
        }
    }

    public void setMovePosition(Vector3 movePosition)
    {
        this.targetPosition = movePosition;
        canMove = true;
    }
}

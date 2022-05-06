using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallAnimState
{
    BALL_IDLE,
    BALL_SELECTED,
    BALL_EXPLODE
}

public class BallAnimationCon : MonoBehaviour
{
    private Animator animator;
    private BallAnimState currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void changeAnimationState(BallAnimState newState)
    {
        if (newState == currentState)
            return;

        switch (newState)
        {
            case BallAnimState.BALL_IDLE:
                animator.Play("IdleAnim");
                break;
            case BallAnimState.BALL_SELECTED:
                animator.Play("SelectedAnim");
                break;
            case BallAnimState.BALL_EXPLODE:
                animator.Play("ExplodeAnim");
                break;
            default:
                break;
        }

        currentState = newState;
    }
}

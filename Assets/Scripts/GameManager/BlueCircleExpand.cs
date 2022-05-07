using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlueExpandAnimState
{
    STANDBY,
    BLUEOUT
}

public class BlueCircleExpand : MonoBehaviour
{
    private Animator animator;
    private BlueExpandAnimState currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void changeAnimationState(BlueExpandAnimState newState)
    {
        if (newState == currentState)
            return;

        switch (newState)
        {
            case BlueExpandAnimState.STANDBY:
                animator.Play("Standby");
                break;
            case BlueExpandAnimState.BLUEOUT:
                animator.Play("CircleExpand");
                break;
            default:
                break;
        }

        currentState = newState;
    }

    public void backToStandbyState()
    {
        currentState = BlueExpandAnimState.STANDBY;
        animator.Play("Standby");
    }
}

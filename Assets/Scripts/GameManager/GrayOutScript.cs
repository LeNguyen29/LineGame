using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrayOutAnimState
{
    STANDBY,
    GRAYOUT
}

public class GrayOutScript : MonoBehaviour
{
    private Animator animator;
    private GrayOutAnimState currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void changeAnimationState(GrayOutAnimState newState)
    {
        if (newState == currentState)
            return;

        switch (newState)
        {
            case GrayOutAnimState.STANDBY:
                animator.Play("Standby");
                break;
            case GrayOutAnimState.GRAYOUT:
                animator.Play("GrayOut");
                break;
            default:
                break;
        }

        currentState = newState;
    }

    public void backToStandbyState()
    {
        currentState = GrayOutAnimState.STANDBY;
        animator.Play("Standby");
    }
}

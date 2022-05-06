using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlackPassByAnimState
{
    PASSBY,
    STANDBY
}

public class BlackPassByScript : MonoBehaviour
{
    private Animator animator;
    private BlackPassByAnimState currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void changeAnimationState(BlackPassByAnimState newState)
    {
        if (newState == currentState)
            return;

        switch (newState)
        {
            case BlackPassByAnimState.STANDBY:
                animator.Play("Standby");
                break;
            case BlackPassByAnimState.PASSBY:
                animator.Play("PassBy");
                break;
            default:
                break;
        }

        currentState = newState;
    }

    public void backToStandbyState()
    {
        currentState = BlackPassByAnimState.STANDBY;
        animator.Play("Standby");
    }
}

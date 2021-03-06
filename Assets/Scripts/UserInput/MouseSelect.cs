using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MouseSelect : MonoBehaviour
{
    private BallManager selectedBall;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
            RaycastHit2D ray = Physics2D.Raycast(mousePos, Vector3.zero);
            Collider2D collider = ray.collider;

            if (selectedBall != null)
            {
                selectedBall.toggleSelect(false);
                selectedBall.ballAnim.changeAnimationState(BallAnimState.BALL_IDLE);
                selectedBall = null;
            }

            if (collider != null)
            {
                selectedBall = collider.GetComponent<BallManager>();

                if (selectedBall != null)
                {
                    Debug.Log(selectedBall.ToString());
                    selectedBall.toggleSelect(true);
                    selectedBall.ballAnim.changeAnimationState(BallAnimState.BALL_SELECTED);
                }
                else
                    Debug.Log("No manager");
            }
        }

        if (Input.GetMouseButtonDown(0))
            selectedBall.ballAnim.changeAnimationState(BallAnimState.BALL_IDLE);
    }

    public void deSelectBall()
    {
        if (selectedBall != null)
        {
            selectedBall.toggleSelect(false);
            selectedBall.ballAnim.changeAnimationState(BallAnimState.BALL_IDLE);
            selectedBall = null;
        }
    }

    public BallManager getSelectedBall()
    {
        return selectedBall;
    }
}

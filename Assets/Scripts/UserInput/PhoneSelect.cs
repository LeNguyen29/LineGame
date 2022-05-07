using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PhoneSelect : MonoBehaviour
{
    private BallManager selectedBall;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.tapCount == 2)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchPos.z = 0f;

                RaycastHit2D ray = Physics2D.Raycast(touchPos, Vector3.zero);
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
                        selectedBall.ballAnim.changeAnimationState(BallAnimState.BALL_SELECTED);
                        selectedBall.toggleSelect(true);
                    }
                    else
                        Debug.Log("No manager");
                }
            }

            if (touch.tapCount == 1)
            {
                if (selectedBall != null)
                    selectedBall.ballAnim.changeAnimationState(BallAnimState.BALL_IDLE);
            }
        }
    }
}
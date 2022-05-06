using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private bool isSelected;
    private BallMovementBase moveBase;
    public BallAnimationCon ballAnim;

    private void Start()
    {
        moveBase = GetComponent<BallMovementBase>();
        ballAnim = GetComponent<BallAnimationCon>();

        isSelected = false;
        //Debug.Log(isSelected);
    }

    private void Update()
    {
        if (isSelected)
        {
            //Debug.Log(isSelected);
            moveBase.Execute();
        }

        if (moveBase.getReachTarget())
        {
            isSelected = false;
            moveBase.setReachTarget(false);
        }
    }

    public void toggleSelect(bool value)
    {
        isSelected = value;
        Debug.Log("SELECTED " + value);
    }

    public override string ToString()
    {
        return gameObject.name;
    }
}

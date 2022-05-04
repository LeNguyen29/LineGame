using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private bool isSelected;
    private BallMovementBase moveBase;

    private void Start()
    {
        moveBase = GetComponent<BallMovementBase>();
        isSelected = false;
        Debug.Log(isSelected);
    }

    private void Update()
    {
        if (isSelected)
        {
            Debug.Log(isSelected);
            moveBase.Execute();
        }

        if (moveBase.reachTarget)
        {
            isSelected = false;
            moveBase.reachTarget = false;
        }
    }

    public void toggleSelect(bool value)
    {
        isSelected = value;
    }

    public override string ToString()
    {
        return gameObject.name;
    }
}

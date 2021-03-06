using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRayShoot : MonoBehaviour
{
    public Transform rightShootPos;
    public Transform leftShootPos;
    public Transform upShootPos;
    public Transform downShootPos;

    public Color color;

    private void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            checkUp();
            checkDown();
            checkLeft();
            checkRight();
        }
    }

    public GameObject checkRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(rightShootPos.position, Vector2.right);
        if (hit.collider != null)
        {
            Debug.Log("Right ray hit " + hit.collider.name);
            return hit.collider.gameObject;
        }

        return null;
    }

    public GameObject checkLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(leftShootPos.position, Vector2.left);
        if (hit.collider != null)
        {
            Debug.Log("Left ray hit " + hit.collider.name);
            return hit.collider.gameObject;
        }

        return null;
    }

    public GameObject checkUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(upShootPos.position, Vector2.up);
        if (hit.collider != null)
        {
            Debug.Log("Up ray hit " + hit.collider.name);
            return hit.collider.gameObject;
        }

        return null;
    }

    public GameObject checkDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(downShootPos.position, Vector2.down);
        if (hit.collider != null)
        {
            Debug.Log("Down ray hit " + hit.collider.name);
            return hit.collider.gameObject;
        }

        return null;
    }
}

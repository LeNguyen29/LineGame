using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRayShootOver : MonoBehaviour
{
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

    public List<GameObject> checkRight()
    {
        List<GameObject> objList = new List<GameObject>();

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                Debug.Log("Right ray hit " + hit.collider.name);
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }

    public List<GameObject> checkLeft()
    {
        List<GameObject> objList = new List<GameObject>();

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.left);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                Debug.Log("Left ray hit " + hit.collider.name);
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }

    public List<GameObject> checkUp()
    {
        List<GameObject> objList = new List<GameObject>();

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.up);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                Debug.Log("Up ray hit " + hit.collider.name);
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }

    public List<GameObject> checkDown()
    {
        List<GameObject> objList = new List<GameObject>();

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                Debug.Log("Down ray hit " + hit.collider.name);
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }
}

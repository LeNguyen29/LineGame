using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRayShootOver : MonoBehaviour
{
    public Transform PointDiagUpRight;
    public Transform PointDiagDownRight;
    public Transform PointDiagUpLeft;
    public Transform PointDiagDownLeft;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
/*            checkUp();
            checkDown();
            checkLeft();
            checkRight();*/
            checkDiagUpRight();
        }
    }

    public List<GameObject> checkDiagUpRight()
    {
        List<GameObject> objList = new List<GameObject>();
        Vector3 direction = (PointDiagUpRight.position - transform.position).normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                //Debug.Log($"Diago Up Right ray hit from {transform.position} " + hit.collider.name);
                Debug.Log($"Distance from {transform.position} to {hit.collider.name}: {Vector3.Distance(transform.position, hit.collider.transform.position)}");
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }

    public List<GameObject> checkDiagDownRight()
    {
        List<GameObject> objList = new List<GameObject>();
        Vector3 direction = (PointDiagDownRight.position - transform.position).normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                //Debug.Log($"Diago Up Right ray hit from {transform.position} " + hit.collider.name);
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }

    public List<GameObject> checkDiagUpLeft()
    {
        List<GameObject> objList = new List<GameObject>();
        Vector3 direction = (PointDiagUpLeft.position - transform.position).normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                //Debug.Log($"Diago Up Right ray hit from {transform.position} " + hit.collider.name);
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }

    public List<GameObject> checkDiagDownLeft()
    {
        List<GameObject> objList = new List<GameObject>();
        Vector3 direction = (PointDiagDownLeft.position - transform.position).normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                //Debug.Log($"Diago Up Right ray hit from {transform.position} " + hit.collider.name);
                Debug.Log($"Distance from {transform.position} to {hit.collider.name}: {Vector3.Distance(transform.position, hit.collider.transform.position)}");
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }

    public List<GameObject> checkRight()
    {
        List<GameObject> objList = new List<GameObject>();

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right);
        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                //Debug.Log("Right ray hit " + hit.collider.name);
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
                //Debug.Log("Left ray hit " + hit.collider.name);
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
                //Debug.Log("Up ray hit " + hit.collider.name);
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
                //Debug.Log("Down ray hit " + hit.collider.name);
                objList.Add(hit.collider.gameObject);
            }
        }

        return objList;
    }
}

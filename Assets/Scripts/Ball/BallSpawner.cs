using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallSpawner : MonoBehaviour
{
    public new GameObject gameObject;
    private GridHandler gridHandler;

    [SerializeField] private int spawnAmount;

    [SerializeField] private List<GameObject> objectList;

    private void Awake()
    {
        gridHandler = FindObjectOfType<GridHandler>();
    }

    private void Start()
    {
        objectList = new List<GameObject>();

        //executeSpawn();

/*        Debug.Log("Walkable node before spawning: " + gridHandler.getWalkableNodeList().Count);

        for (int i = 0; i < spawnAmount; i++)
        {
            spawnObject(getRandomGridPos(), Quaternion.identity);
        }

        Debug.Log("Walkable node after spawning: " + gridHandler.getWalkableNodeList().Count);*/

        /*        foreach (var obj in objectList)
                {
                    gridHandler.getPathFinder().getNode(obj.transform.position).setWalkable(false);
                }*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gridHandler.getWalkableNodeList().Count > 0)
                spawnObject(getRandomGridPos(), Quaternion.identity);
            else
                Debug.Log("No more walkable node");
        }
    }

    public void executeSpawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            if (gridHandler.getWalkableNodeList().Count > 0)
                spawnObject(getRandomGridPos(), Quaternion.identity);
            else
                Debug.Log("No more walkable node");
        }
    }

    public void spawnObject(Vector3 spawnPosition, Quaternion quaternion)
    {
        GameObject temp = Instantiate(gameObject, spawnPosition, quaternion);
        objectList.Add(temp);
        gridHandler.getPathFinder().getNode(temp.transform.position).setWalkable(false);

        /*        if (gridHandler.getWalkableNodeList().Count > 0)
                {
                    GameObject temp = Instantiate(gameObject, spawnPosition, quaternion);
                    objectList.Add(temp);
                    gridHandler.getPathFinder().getNode(temp.transform.position).setWalkable(false);
                }
                else
                {
                    Debug.Log("No more walkable node");
                }*/
    }

    public Vector3 getRandomGridPos()
    {
        int x = UnityEngine.Random.Range(0, gridHandler.width);
        int y = UnityEngine.Random.Range(0, gridHandler.height);

        while (!gridHandler.getPathFinder().getNode(x, y).isWalkable)
        {
            x = UnityEngine.Random.Range(0, gridHandler.width);
            y = UnityEngine.Random.Range(0, gridHandler.height);

            if (gridHandler.getWalkableNodeList().Count <= 0)
                break;
        }

        Debug.Log($"Node spawn: {x},{y}");

        Vector3 spawnPos = gridHandler.getPathFinder().getNodeWorldPosition(x, y) + Vector3.one * gridHandler.cellSize * 0.5f;

        return spawnPos;
    }
}

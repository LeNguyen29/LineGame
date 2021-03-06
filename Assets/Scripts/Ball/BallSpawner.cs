using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;
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

/*        Debug.Log("Walkable node before spawning: " + gridHandler.getWalkableNodeList().Count);

        for (int i = 0; i < spawnAmount; i++)
        {
            spawnObject(getRandomGridPos(), Quaternion.identity);
        }

        Debug.Log("Walkable node after spawning: " + gridHandler.getWalkableNodeList().Count);*/
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
        GameObject temp = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], spawnPosition, quaternion);
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

    public List<GameObject> getBallList()
    {
        return objectList;
    }
}

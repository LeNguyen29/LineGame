using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GridHandler gridHandler;
    public float offset;

    private void Start()
    {
        int width, height;

        gridHandler.getGridSize(out width, out height);

        // Camera orthographic size base on map width
        // float orthoSize = sprite.bounds.size.x * Screen.height / Screen.width * 0.5f;

        // Camera orthographic size base on map height
        // float orthoSize = sprite.bounds.size.y / 2;

        //Camera.main.orthographicSize = orthoSize;

        float screenRatio = Screen.width / Screen.height;
        float targetRatio = width / height;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = height / 2 + offset;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = height / 2 * differenceInSize + offset;
        }
    }
}

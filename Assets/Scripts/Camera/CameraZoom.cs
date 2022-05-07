using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public SpriteRenderer sprite;

    private void Start()
    {
        // Camera orthographic size base on map width
        // float orthoSize = sprite.bounds.size.x * Screen.height / Screen.width * 0.5f;

        // Camera orthographic size base on map height
        // float orthoSize = sprite.bounds.size.y / 2;

        //Camera.main.orthographicSize = orthoSize;

        float screenRatio = Screen.width / Screen.height;
        float targetRatio = sprite.bounds.size.x / sprite.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = sprite.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = sprite.bounds.size.y / 2 * differenceInSize;
        }
    }
}

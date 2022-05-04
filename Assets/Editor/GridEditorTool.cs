using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridHandler))]
public class GridEditorTool : Editor
{
    float scaleHandleSize;

    private void OnSceneGUI()
    {
        Handles.color = Color.white;

        GridHandler testData = (GridHandler)target;

        Vector3 position = testData.transform.position;

        Handles.DrawWireCube(position, new Vector3(testData.width * testData.cellSize, testData.height * testData.cellSize));

        Handles.Label(position + Vector3.left * (testData.width * 0.5f + 0.5f), testData.ToString());

        Handles.color = Color.blue;

        //float size = (testData.width * testData.height) / testData.cellSize;
        scaleHandleSize = HandleUtility.GetHandleSize(position) * 2f;

        float temp = Handles.ScaleValueHandle(
            testData.width,
            position + Vector3.right * (testData.width * testData.cellSize * 0.5f),
            Quaternion.identity,
            scaleHandleSize,
            Handles.CubeHandleCap,
            1);

        float temp2 = Handles.ScaleValueHandle(testData.height,
            position + Vector3.up * (testData.height * testData.cellSize * 0.5f),
            Quaternion.identity,
            scaleHandleSize,
            Handles.CubeHandleCap,
            1);

        testData.width = (int)temp;
        testData.height = (int)temp2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorChanger : MonoBehaviour
{
    private SpriteRenderer sprite;

    private Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan };

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        changeColor();
    }

    public void changeColor()
    {
        sprite.color = pickRandomColor();
    }

    public Color pickRandomColor()
    {
        int i = Random.Range(0, colors.Length);
        return colors[i];
    }
}

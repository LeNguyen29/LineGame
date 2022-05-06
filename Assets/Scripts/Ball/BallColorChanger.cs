using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorChanger : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Ball ball;
    private Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan };

    void Start()
    {
        ball = GetComponent<Ball>();
        sprite = GetComponent<SpriteRenderer>();
        if (ball.type == BallType.NORMAL)
            changeColor();
    }

    public void changeColor()
    {
        sprite.color = pickRandomColor();
        ball.color = sprite.color;
    }

    public Color pickRandomColor()
    {
        int i = Random.Range(0, colors.Length);
        return colors[i];
    }
}

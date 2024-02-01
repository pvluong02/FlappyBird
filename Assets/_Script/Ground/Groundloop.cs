using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Groundloop : MonoBehaviour
{
    public float speed = 1.3f;
    public float with = 6f;

    private SpriteRenderer spriteRenderer;
    private Vector2 startSize;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);

    }

    private void Update()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime, spriteRenderer.size.y);

        if (spriteRenderer.size.x > with)
        {
            spriteRenderer.size = startSize;
        }
    }
}

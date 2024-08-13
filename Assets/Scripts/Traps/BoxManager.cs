using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite c2Sprite;
    public Sprite c1Sprite;
    public bool C1Active = true;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeSprite();
        }
    }

    public void ChangeSprite()
    {
        if (C1Active)
        {
            C1Active = false;
            spriteRenderer.sprite = c1Sprite;
            body.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            C1Active = true;
            spriteRenderer.sprite = c2Sprite;
            body.bodyType = RigidbodyType2D.Static;
        }
    }

}

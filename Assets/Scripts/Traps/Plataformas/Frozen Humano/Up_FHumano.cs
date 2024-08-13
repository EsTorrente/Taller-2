using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_FHumano : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingDown;
    private float bottomEdge;
    private float topEdge;

    public SpriteRenderer spriteRenderer;
    public Sprite c2Sprite;
    public Sprite c1Sprite;
    private bool C1Active = true;
    private Rigidbody2D body;

    private void Awake()
    {
        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
    }

    private void FixedUpdate()
    {
        if (!C1Active)
        {
            if (movingDown)
            {
                if (transform.position.y > bottomEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.fixedDeltaTime, transform.position.z);
                }
                else
                    movingDown = false;
            }
            else
            {
                if (transform.position.y < topEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.fixedDeltaTime, transform.position.z);
                }
                else
                    movingDown = true;
            }
        }

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
        }
        else
        {
            C1Active = true;
            spriteRenderer.sprite = c2Sprite;
        }
    }
}

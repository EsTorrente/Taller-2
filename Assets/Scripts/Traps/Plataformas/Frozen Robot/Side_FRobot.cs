using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_FRobot : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    public SpriteRenderer spriteRenderer;
    public Sprite c2Sprite;
    public Sprite c1Sprite;
    private bool C1Active = true;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void FixedUpdate()
    {
        if (C1Active)
        {
            if (movingLeft)
            {
                if (transform.position.x > leftEdge)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
                }
                else
                    movingLeft = false;
            }
            else
            {
                if (transform.position.x < rightEdge)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
                }
                else
                    movingLeft = true;
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

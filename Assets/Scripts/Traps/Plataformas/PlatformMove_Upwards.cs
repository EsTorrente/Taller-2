using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove_Upwards : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingDown;
    private float bottomEdge;
    private float topEdge;

    private void Awake()
    {
        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
    }

    private void FixedUpdate()
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
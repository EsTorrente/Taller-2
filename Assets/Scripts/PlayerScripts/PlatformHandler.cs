using UnityEngine;

public class PlatformHandler : MonoBehaviour
{
    private Transform currentPlatform;
    private Vector3 previousPlatformPosition;
    private Animator anim;
    private bool isPushing;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (currentPlatform != null)
        {
            Debug.Log("Fixed update bien");
            Vector3 platformMovement = currentPlatform.position - previousPlatformPosition;
            transform.position += platformMovement;
            previousPlatformPosition = currentPlatform.position;
        }
    }

    private void Update()
    {
        anim.SetBool("Pushing", isPushing == true);
    }

    // Handle all collisions here
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("On collision with Platform.");
            currentPlatform = collision.transform;
            previousPlatformPosition = currentPlatform.position;
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("On collision with Box.");
            isPushing = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Exit collision with Platform");
            currentPlatform = null;
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Exit collision with Box");
            isPushing = false;

        }
    }

}

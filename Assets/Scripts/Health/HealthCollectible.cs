using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite c2Sprite;
    public Sprite c1Sprite;
    public bool C1Active = true;

    public AudioSource audioSource;
    [SerializeField] public AudioClip collectibleSound;

    [SerializeField] private float healthValue;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(collectibleSound, 1f);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
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
            spriteRenderer.sprite = c2Sprite;
        }
        else
        {
            C1Active = true;
            spriteRenderer.sprite = c1Sprite;
        }
    }
}
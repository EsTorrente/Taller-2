using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollectible : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] public AudioClip collectibleSound;
   
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(collectibleSound, 0.4f);
        }
        
    }
}

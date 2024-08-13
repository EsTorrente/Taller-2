using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public bool C1Active = true;
    private Animator anim;

    [Header("SONIDOS")]
    // SONIDOS ----------------------------------
    public AudioSource audioSource;
    public float audioCooldown = 1f;
    private bool inCooldown;
    [SerializeField] public AudioClip switchSound;

    [Header("SONIDOS HUMANO")]
    //sonidos humano
    [SerializeField] public AudioClip hurt1Sound;
    [SerializeField] public AudioClip jump1Sound;
    [SerializeField] public AudioClip dashSound;
    [SerializeField] public AudioClip die1Sound;

    [Header("SONIDOS ROBOT")]
    //sonidos robot
    [SerializeField] public AudioClip hurt2Sound;
    [SerializeField] public AudioClip jump2Sound;
    [SerializeField] public AudioClip attackSound;
    [SerializeField] public AudioClip die2Sound;

    private void Awake()
    {
        //agarrar referencias del rigid body y animator
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            audioSource.PlayOneShot(switchSound, 0.4f);

            if (C1Active == true)
            {
                C1Active = false;
            }
            else
            {
                C1Active = true;
            }
        }

        //sonidos humano
        if (C1Active)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(jump1Sound, 0.4f);
                StartCoroutine(Cooldown());
            }

            if (anim.GetBool("hurt") == true)
            {
                audioSource.PlayOneShot(hurt1Sound, 0.4f);
                StartCoroutine(Cooldown());
            }

            if (anim.GetBool("die") == true)
            {
                audioSource.PlayOneShot(die1Sound, 0.4f);
                StartCoroutine(Cooldown());
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                audioSource.PlayOneShot(dashSound, 0.4f);
                StartCoroutine(Cooldown());
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(jump2Sound, 0.2f);
                StartCoroutine(Cooldown());
            }

            if (anim.GetBool("hurt") == true)
            {
                audioSource.PlayOneShot(hurt2Sound, 0.4f);
                StartCoroutine(Cooldown());
            }

            if (anim.GetBool("die") == true)
            {
                audioSource.PlayOneShot(die2Sound, 0.4f);
                StartCoroutine(Cooldown());
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                audioSource.PlayOneShot(attackSound, 0.2f);
            }

        }
    }

    private IEnumerator Cooldown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(audioCooldown);
        inCooldown = false;
    }
}

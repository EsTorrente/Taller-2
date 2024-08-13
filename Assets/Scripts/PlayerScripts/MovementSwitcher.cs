using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MovementSwitcher : MonoBehaviour
{
    public C1Movement c1Movement;
    public C2Movement c2Movement;
    public PlatformHandler platformHandler;

    //animaciones y skins
    private Animator anim;
    public RuntimeAnimatorController animControl1;
    public RuntimeAnimatorController animControl2;
    public bool C1Active = true;

    private void Awake()
    {
        //agarrar referencias del rigid body y animator
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        // Initially enable C1Movement and disable C2Movement
        platformHandler.enabled = true;
        anim.SetTrigger("Character1");
        c1Movement.enabled = true;
        c2Movement.enabled = false;
        anim.runtimeAnimatorController = animControl1;
    }

    private void Update()
    {
        // Check if the X key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchMovement();
        }

    }

    private void SwitchMovement()
    {
        if (C1Active)
        {
            C1Active = false;
            // Switch to C2Movement
            anim.ResetTrigger("Character1");
            anim.SetTrigger("Character2");
            c1Movement.enabled = false;
            c2Movement.enabled = true;
            anim.runtimeAnimatorController = animControl2;
        }
        else
        {
            C1Active = true;
            // Switch to C1Movement
            anim.ResetTrigger("Character2");
            anim.SetTrigger("Character1");
            c1Movement.enabled = true;
            c2Movement.enabled = false;
            anim.runtimeAnimatorController = animControl1;
        }
        // Sync the C1Active state with the Health script
        var health = GetComponent<Health>();
        if (health != null)
        {
            health.C1Active = C1Active;
        }

    }

}

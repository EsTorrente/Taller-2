using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;

    private Animator anim;
    private C2Movement c2Mov;
    private MovementSwitcher movSwitch;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        c2Mov = GetComponent <C2Movement>();
        movSwitch = GetComponent<MovementSwitcher>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z) && cooldownTimer > attackCooldown && c2Mov.canAttack() && !movSwitch.C1Active)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        //pooling de proyectiles
        projectiles[FindProjectile()].transform.position = firePoint.position;
        projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}

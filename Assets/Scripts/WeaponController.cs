using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject meleeWeapon;
    public bool canAttack = true;
    public float attackCooldown = 1f;

    public bool isAttacking = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;

        canAttack = false;

        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true; 
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}

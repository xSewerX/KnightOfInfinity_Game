using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public LayerMask enemyLayer;


    public Transform attackPoint;
    public float attackRange = 1f;

    public int AttackDamage = 10;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("BasicAttack"))
            {
                BasicAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }


    void BasicAttack()
    {
        anim.SetTrigger("Attack");
        //Debug.Log("Attack Animation");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("Uderzyles " + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(AttackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}

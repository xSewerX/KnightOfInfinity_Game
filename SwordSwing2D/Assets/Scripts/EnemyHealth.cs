using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int CurrentHealth;
    public GameObject EnemyObject;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        anim.SetTrigger("Hit");
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {

        Debug.Log("Enemy died");
        EnemyObject.SetActive(false);

    }
}

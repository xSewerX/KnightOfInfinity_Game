using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int CurrentHealth;
    public GameObject EnemyObject;

    private Animator anim;
    public double points;

    private Player player;

    void Start()
    {
        anim = GetComponent<Animator>();
        CurrentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        player.AddPoints(points);
        Debug.Log("Enemy died");
        Destroy(gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int StartHP;
    public int AddHealth;
    public int maxHealth;
    int CurrentHealth;
    private Animator anim;
    public double points;
    public GameObject HpRegeneration;

    private Player player;

    void Start()
    {
        maxHealth = StartHP + AddHealth;
        anim = GetComponent<Animator>();
        CurrentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        maxHealth = StartHP + AddHealth;
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
        int number = Random.Range(0, 2);
        if(number == 1)
        {
        Instantiate(HpRegeneration, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
    public void AddBonusHealth(int healthamount)
    {
        AddHealth += healthamount;
        Debug.Log("Dodano zdrowie");
    }
}

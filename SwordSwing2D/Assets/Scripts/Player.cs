using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            AddMaxHealth(10);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Heal(5);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public void AddMaxHealth(int addHealth)
    {
        maxHealth += addHealth;
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        healthbar.SetHealth(currentHealth);
    }
}

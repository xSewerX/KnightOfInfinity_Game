using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public int AttackDamage = 10;

    [HideInInspector] public double BonusPointsProcent = 0;
    [HideInInspector] public double points = 0;
    public double PointsOverall = 0;

    public GameObject EQANDStats;
    public GameObject HUD;

    public HealthBar healthbar;
    public TMP_Text PointsLabel;


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        PointsLabel.text = PointsOverall.ToString();

        PointsLabel.text = PointsOverall+"";

        if (Input.GetKeyDown("escape"))
        {
            EQANDStats.SetActive(true);
            HUD.SetActive(false);
           // Time.timeScale = 0;

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

    public void AddPoints(double points)
    {
        PointsOverall += points + (points * (BonusPointsProcent * 0.01));
        Debug.Log(PointsOverall);
    }
}

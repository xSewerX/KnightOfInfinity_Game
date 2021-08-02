using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeCharacter : MonoBehaviour
{
    public Player player;
    public PlayerAttack playerattack;

    public TMP_Text HealthLabel;
    int HealthMax;
    int HealthCurrent;

    public TMP_Text PointsLabel;
    double Points;

    public TMP_Text AttackLabel;
    int Strength;

    int CostBonus = 1;
    int CostStamina = 1;
    int CostStrength = 1;
    
    public TMP_Text CostBonusLabel;
    public TMP_Text CostStaminaLabel;
    public TMP_Text CostStrengthLabel;

    void Update()
    {
        HealthMax = player.maxHealth;
        HealthCurrent = player.currentHealth;
        HealthLabel.text = HealthCurrent.ToString();
        HealthLabel.text = HealthMax.ToString();
        HealthLabel.text = HealthCurrent + "/" + HealthMax;

        Points = player.PointsOverall;
        PointsLabel.text = Points.ToString();
        PointsLabel.text = Points + " (+" + player.BonusPointsProcent + "%)";

        Strength = playerattack.AttackDamage;
        AttackLabel.text = Strength.ToString();
        AttackLabel.text = Strength + "";

        CostBonusLabel.text = CostBonus+"";
        CostStaminaLabel.text = CostStamina + "";
        CostStrengthLabel.text = CostStrength + "";

    }
    public void AddStamina()
    {
        if (Points >= CostStamina)
        {
            player.AddMaxHealth(5);
            player.Heal(5);
            player.PointsOverall -= CostStamina;
            CostStamina += 1;
        }
        else
        {
            Debug.Log("Not enough ponits");
        }
    }

    public void AddBonusPoints()
    {
        if (Points >= CostBonus)
        {
            player.BonusPointsProcent += 1;
            player.PointsOverall -= CostBonus;
            CostBonus += 1;
        }
        else
        {
            Debug.Log("Not enough ponits");
        }
    }

    public void AddStrength()
    {
        if (Points >= CostStrength)
        {
            playerattack.AttackDamage += 1;
            player.PointsOverall -= CostStrength;
            CostStrength += 1;
        }
        else
        {
            Debug.Log("Not enough ponits");
        }
    }
}

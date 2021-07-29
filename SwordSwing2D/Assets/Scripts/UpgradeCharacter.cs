using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeCharacter : MonoBehaviour
{
    public Player player;
    public TMP_Text HealthLabel;
    int HealthMax;
    int HealthCurrent;

    void Update()
    {
        HealthMax = player.maxHealth;
        HealthCurrent = player.currentHealth;

        HealthLabel.text = HealthCurrent.ToString();
        HealthLabel.text = HealthMax.ToString();

        HealthLabel.text = HealthCurrent + "/" + HealthMax;
    }
    public void AddStamina()
    {
        player.AddMaxHealth(5);
        HealthMax = player.maxHealth;
        
    }
}

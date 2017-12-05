using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float currentHealth = 1000;
    public float maxHealth = 1000;
    public float passiveHealthRegen = 2;
    public Image healthBar;

    public void Start()
    {
        currentHealth = 1000;
    }

    public void Update()
    {
        IncreaseHealthPassively(passiveHealthRegen);
        FillHealthBar();
    }

    private void FillHealthBar()
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void AddHealth(float health)
    {
        currentHealth += health;
    }

    public void IncreaseHealthPassively(float regen)
    {
        if (currentHealth < maxHealth)
            currentHealth += regen;
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float currentHealth = 1000;
    public float maxHealth = 1000;
    public float passiveHealthRegen = 2;
    public Image healthBar;
    private SpellsController player;
    private Animator anim;
    private Rigidbody rb;

    public void Start()
    {
        currentHealth = 1000;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellsController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("IsDead", true);
            Invoke("Freeze", 1.5f);
        }

        IncreaseHealthPassively(passiveHealthRegen);
        FillHealthBar(); 
    }

    private void FillHealthBar()
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if(!player.isShielded)
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

    public void Freeze()
    {
        //to do
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        Time.timeScale = 0;
    }

    public void IncreaseMaxHp()
    {
        maxHealth += 50;
    }

}
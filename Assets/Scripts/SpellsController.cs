﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsController : MonoBehaviour {

    public GameObject fireBall;
    public GameObject lightningStorm;
    public GameObject magicShield;
    public Transform spellSpawn;
    public Transform auraSpawn;

    public float fireBallRequiredMana = 50;
    public float thunderStormRequiredMana = 100;
    public float magicShieldRequiredMana = 100;
    public float magicShieldTime = 4;

    private ManaManager manaManager;
    private HealthManager healthManager;
    private Animator animator;
    public bool isShielded;

    public void Start()
    {
        manaManager = GetComponent<ManaManager>();
        animator = GetComponent<Animator>();
        healthManager = GetComponent<HealthManager>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (manaManager.currentMana >= fireBallRequiredMana)
            {
                manaManager.DesreaseAmount(fireBallRequiredMana);
                GameObject fireBallClone = Instantiate(fireBall, spellSpawn.position, spellSpawn.rotation) as GameObject;
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (manaManager.currentMana >= thunderStormRequiredMana)
            {
                manaManager.DesreaseAmount(thunderStormRequiredMana);
                GameObject lightningStormClone = Instantiate(lightningStorm, spellSpawn.position, spellSpawn.rotation) as GameObject;
                Destroy(lightningStormClone, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (manaManager.currentMana >= magicShieldRequiredMana)
            {
                isShielded = true;
                Invoke("DisableMagicShield", magicShieldTime);
                manaManager.DesreaseAmount(magicShieldRequiredMana);
                Instantiate(magicShield, auraSpawn.position, auraSpawn.rotation);
            }
        }
    }

    public void DisableMagicShield()
    {
        isShielded = false;
    }
}

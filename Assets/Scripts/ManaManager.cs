using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour {


    public float passiveManaRegen = 2;
    public float currentMana = 500;
    public float maxMana = 500;
    public Image manaBar;


    public void Update()
    {
        IncreaseManaPassively(passiveManaRegen);
        FillManaBar();
    }

    private void FillManaBar()
    {
        manaBar.fillAmount = (currentMana / maxMana);
    }

    public void DesreaseAmount(float spellRequiredMana)
    {
        currentMana -= spellRequiredMana;
        manaBar.fillAmount = (currentMana/maxMana);
    }

    public void IncreaseManaPassively(float regen)
    {
        if (currentMana < maxMana)
        {
            currentMana += regen;
            manaBar.fillAmount = (currentMana / maxMana);
        }
    }
}

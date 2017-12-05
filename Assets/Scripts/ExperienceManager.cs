using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour {

    public Image experienceBar;
    public Text exp;
    public Text lvl;
    public float currentExperience;
    private float experienceForCurrentLevel;
    public float experienceForNextLevel;
    public float level;

    public void Start()
    {
        currentExperience = 0;
        level = 1;
    }

    public void Update()
    {
        UpdateExperience();      
        ManageLevels();      
    }

    private void UpdateExperience()
    {
        FillExperienceBar();
        FillExperienceText();
        FillLevelText();
    }

    private void FillLevelText()
    {
        string template = "Level: {0}";

        lvl.text = string.Format(template, level.ToString());
    }

    private void FillExperienceText()
    {
        string template = "{0}/{1}";

        exp.text = string.Format(template, currentExperience.ToString(), experienceForNextLevel.ToString());
    }

    private void ManageLevels()
    {
        experienceForCurrentLevel = experienceForNextLevel;

        if (currentExperience >= experienceForNextLevel)
        {
            ResetExperienceBar();
            float extraExp = GetExtraExp(currentExperience, experienceForNextLevel);
            level += 1;
            currentExperience = extraExp;
            experienceForNextLevel = CalculateExperienceForNextLevel();
        }
    }

    private float GetExtraExp(float currExp, float nextLevelExp)
    {
        return currentExperience - nextLevelExp;
    }

    private void ResetExperienceBar()
    {
        experienceBar.fillAmount = 0;
    }

    public void Add(float experience)
    {
        currentExperience += experience;
        
    }

    public void FillExperienceBar()
    {
        experienceBar.fillAmount = (currentExperience / experienceForNextLevel);
    }

    public float CalculateExperienceForNextLevel()
    {
        float temp =  experienceForCurrentLevel / 100 * 140;

        for(int i = 0; i < 10; i ++)
        {
            if (temp % 10 != 0)
                temp += 1;
            else
                break;
        }
        return temp;
    }
}

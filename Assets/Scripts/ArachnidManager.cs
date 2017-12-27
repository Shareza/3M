using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArachnidManager : MonoBehaviour {

    public float currentHealth = 1000;
    public float maxHealth = 1000;
    public float experience = 100;

    public Image healthImage;
    private ExperienceManager experienceManager;
    private Animator anim;

	void Start ()
    {
        experienceManager = GameObject.Find("Player").GetComponent<ExperienceManager>();
        anim = GetComponent<Animator>();
	}
	

	void Update ()
    {
        healthImage.fillAmount = (currentHealth / maxHealth);

        if(currentHealth < 0)
        {
            experienceManager.Add(experience);
            anim.SetBool("IsDead", true);
            Destroy(gameObject);
        }
	}

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}

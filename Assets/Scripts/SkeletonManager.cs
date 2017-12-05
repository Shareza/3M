using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonManager : MonoBehaviour
{


    public float currentHealth = 700;
    public float maxHealth = 700;
    public float experience = 50;

    public Image healthImage;

    public GameObject medicalKit;
    private ExperienceManager experienceManager;

    void Start()
    {
        experienceManager = GameObject.Find("Player").GetComponent<ExperienceManager>();
    }

    void Update()
    {
        healthImage.fillAmount = (currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            experienceManager.Add(experience);
            Destroy(gameObject);   
            //DropItems();  
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void DropItems()
    {
        var seed = Random.Range(1, 10);

        if (seed > 5)
            Instantiate(medicalKit, transform.position, Quaternion.identity);
    }


}

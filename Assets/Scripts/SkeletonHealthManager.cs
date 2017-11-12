using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealthManager : MonoBehaviour
{


    public float health = 1000;
    public Image healthImage;


    void Update()
    {
        healthImage.fillAmount = (health / 1000);

        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}

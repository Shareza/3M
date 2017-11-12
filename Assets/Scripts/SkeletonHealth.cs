using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealth : MonoBehaviour
{
    public float health;
    public Image healthImage;

    void Update()
    {
        healthImage.fillAmount = (health / 100);
    }

    public void TakeDamage(float damage)
    {

    }
}

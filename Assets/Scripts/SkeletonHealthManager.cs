using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealthManager : MonoBehaviour
{


    public float health = 1000;
    public Image healthImage;
    public GameObject combatText;


    void Update()
    {
        healthImage.fillAmount = (health / 1000);

        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        InitCombatText(damage.ToString());
    }

    void InitCombatText(string damage)
    {
        GameObject temp = Instantiate(combatText) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.FindChild("HUD"));
        tempRect.transform.localPosition = combatText.transform.localPosition;
        tempRect.transform.localScale = combatText.transform.localScale;
        temp.GetComponent<Text>().text = damage;
        temp.GetComponent<Animator>().SetTrigger("Hit");

        Destroy(temp.gameObject, 2);
    }

}

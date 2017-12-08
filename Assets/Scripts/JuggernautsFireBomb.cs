using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautsFireBomb : MonoBehaviour
{

    public float time = 5.0f;
    public float range = 10.0f;
    public float damage = 500;
    public GameObject explosion;

    private GameObject player;
    private HealthManager playerHealthManager;

    void Start()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        playerHealthManager = GetComponent<HealthManager>();
        Invoke("DealDamage", 2.0f);
        Destroy(gameObject, time);
    }

    public void DealDamage()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (InRange())
        {
            playerHealthManager.TakeDamage(damage);
        }

            
    }

    private bool InRange()
    {
        var distance = player.transform.position.x - transform.position.x;

        if (distance <= range)
            return true;
        return false;
    }
}
	

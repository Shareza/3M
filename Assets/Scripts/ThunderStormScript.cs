using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStormScript : MonoBehaviour {


    public float minDamage = 10;
    public float maxDamage = 25;
    public float power = 5;
    public float speed = 0.5f;


    private DamageManager damageManager;
    Collision collision;

	void Start ()
    {
        damageManager = new DamageManager();
	}
	
	void Update ()
    {
        DealDamage(collision);
	}

    public void DealDamage(Collision other)
    {
        float damage = damageManager.GenerateDamage(power, minDamage, maxDamage);
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, 8);

        foreach (var enemy in enemiesInRange)
        {
            if(enemy.tag == "Enemy")
                enemy.SendMessage("TakeDamage", damage / 30);
        }

    }
}

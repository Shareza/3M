using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FireBallScript : MonoBehaviour {

    Collision collision;
    Rigidbody rb;
    DamageManager damageManager = new DamageManager();

    public GameObject explosion;
    public float minDamage = 10;
    public float maxDamage = 25;
    public float power = 10;
    public float speed = 1.5f;
    public float lifeTime = 1.0f;

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        DestroyFireBallAfterLifeTimeFades();
        OnCollisionEnter(collision);  
    }

    private void DestroyFireBallAfterLifeTimeFades()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Shootable")
        {
            explosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
        DealDamage(other);
    }

    public void DealDamage(Collision other)
    {
        float damage = damageManager.GenerateDamage(power, minDamage, maxDamage);

        other.gameObject.GetComponent<SkeletonHealthManager>().TakeDamage(damage);
    }
}

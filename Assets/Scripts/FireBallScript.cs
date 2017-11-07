using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour {

    Collision collision;
    Rigidbody rb;

    public GameObject explosion;
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

    private void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Shootable")
        {
            explosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour {

    Rigidbody rb;
    public float speed = 1.5f;
    public float lifeTime = 1;
    Collision col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        OnCollisionEnter(col);
        DestroyFireBallAfterLifeTimeFades();
    }

    private void DestroyFireBallAfterLifeTimeFades()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Shootable")
            Destroy(gameObject);
    }
}

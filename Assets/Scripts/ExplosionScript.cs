using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    private float lifeTime = 1.0f;

	void Update ()
    {
        Destroy(gameObject, lifeTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsController : MonoBehaviour {

    public GameObject fireBall;
    public Transform fireBallSpawn;
    public float fireRate;
    public float nextFire;
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFire)
        {
            nextFire = Time.time * fireRate;
            GameObject clone = Instantiate(fireBall, fireBallSpawn.position, fireBallSpawn.rotation) as GameObject;
        }
    }
}

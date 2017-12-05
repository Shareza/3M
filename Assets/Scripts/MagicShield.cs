using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MonoBehaviour {

    private float time;

    private void Start()
    {
        time = GetComponent<SpellsController>().magicShieldTime;
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update ()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        
	}
}

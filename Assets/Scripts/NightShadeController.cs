using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShadeController : MonoBehaviour {

    public float range = 5;
    public float speed = 4;

    private GameObject player;
    private CharacterController controller;
    private Animator anim;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
		// make hp bar visible
	}
	
	
	void Update ()
    {
        Chase();

        //if in range cast spell -> fire bomb
	}

    private void Chase()
    {
        transform.LookAt(player.transform);
        controller.SimpleMove(transform.forward * speed);
        anim.SetBool("IsWalking", true);

        
    }

    bool InRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

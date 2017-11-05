using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {


    public float speed;
    public float range;
    public CharacterController controller;
    public Transform player;

    public Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Chase();	
	}

    bool InRange()
    {
        if(Vector3.Distance(transform.position, player.position) < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Chase()
    {
        transform.LookAt(player.position);
        controller.SimpleMove(transform.forward * speed);
        animator.SetBool("IsWalking", true);

    }
}

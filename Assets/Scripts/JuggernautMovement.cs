using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautMovement : MonoBehaviour {

    public float speed;
    public float range;
    public GameObject fireBomb;
    public Transform player;
    private CharacterController controller;
    private Animator animator;

    


	void Start ()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        animator.SetBool("IsWalking", true);
        Chase();

        if (InRange())
        {
            animator.SetBool("IsWalking", false);
            RandomAttackAnimation();
        }

        SummonFire();
    }

    private void SummonFire()
    {
        var seed = UnityEngine.Random.Range(0, 50);

        if(seed > 45)
        {
            //animator.SetTrigger("SummonFire");
            Instantiate(fireBomb, player.position, player.rotation);
        }
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

    void Chase()
    {

        transform.LookAt(player.transform.position);
        controller.SimpleMove(transform.forward * speed);
        animator.SetBool("IsWalking", true);

    }

    void RandomAttackAnimation()
    {
        int seed = UnityEngine.Random.Range(0, 2);

        switch(seed)
        {
            case 0:
                animator.SetTrigger("SingleAttack");
                break;

            case 1:
                animator.SetTrigger("DoubleAttack");
                break;
        }

    }
}

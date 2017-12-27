using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautMovement : MonoBehaviour {

    public float speed;
    public float range = 5;
    public float singleAttackDamage = 40;
    public float doubleAttackDamage = 80;

    private bool canMove;
    private GameObject player;
    private CharacterController controller;
    private Animator animator;
    private HealthManager playerHealth;
    


	void Start ()
    {
        player = GameObject.Find("Player");
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerHealth = GameObject.Find("Player").GetComponent<HealthManager>();
        canMove = true;
	}
	
	void Update ()
    {
        transform.LookAt(player.transform.position);
        Chase();

        if (InRange())
        {
            StopMoving(); 
            AttackAnimation();
            Invoke("BackToMoving", 2.0f);
        }
    }

    public void BackToMoving()
    {
        canMove = true;
    }

    private void StopMoving()
    {
        canMove = false;
        animator.SetBool("IsWalking", false);
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

        if (canMove)
        {
            transform.LookAt(player.transform.position);
            controller.SimpleMove(transform.forward * speed);
            animator.SetBool("IsWalking", true);
        }

    }

    void AttackAnimation()
    {
        int seed = UnityEngine.Random.Range(0, 2);

        switch(seed)
        {
            case 0:
                SingleAttack();
                break;

            case 1:
                DoubleAttack();
                break;
        }

    }

    private void DoubleAttack()
    {
        animator.SetTrigger("DoubleAttack");
            playerHealth.TakeDamage(doubleAttackDamage);
    }

    private void SingleAttack()
    {
        animator.SetTrigger("SingleAttack");
            playerHealth.TakeDamage(singleAttackDamage);

    }
}

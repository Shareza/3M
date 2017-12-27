using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArachnidMovement : MonoBehaviour {

    public float speed = 4;
    public float range = 3;
    public float damage = 6;


    private GameObject player;
    private CharacterController controller;
    private Animator anim;
    private HealthManager playerHealthManager;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerHealthManager = GameObject.Find("Player").GetComponent<HealthManager>();
	}
	

	void Update ()
    {
        Chase();

        if (InRange())
        {
            anim.SetBool("IsWalking", false);
            anim.SetTrigger("Attack");
            playerHealthManager.TakeDamage(damage);
        }
	}

    public void Chase()
    {
        transform.LookAt(player.transform.position);
        controller.SimpleMove(transform.forward * speed);
        anim.SetBool("IsWalking", true);
    }

    public bool InRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
            return true;
        return false;
    }
}

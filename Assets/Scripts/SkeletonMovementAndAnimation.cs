using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovementAndAnimation : MonoBehaviour {


    public float speed;
    public float range = 3;
    public float damage = 10;

    public CharacterController controller;
    public GameObject player;
    public Animator animator;
    public GameObject spawnAnimation;
    public Transform spawnAura;

    private HealthManager playerHealthManager;
    
	void Start () {
        animator = GetComponent<Animator>();
        playerHealthManager = GameObject.Find("Player").GetComponent<HealthManager>();
        Instantiate(spawnAnimation, spawnAura.position, spawnAura.rotation);
    }
	
	void Update ()
    {
        Chase();
        
        if(InRange())
        {
            animator.SetBool("IsWalking", false);
            animator.SetTrigger("Attack");
            playerHealthManager.TakeDamage(damage);


        }
	}

    bool InRange()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < range)
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
        player = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(player.transform.position);
        controller.SimpleMove(transform.forward * speed);
        animator.SetBool("IsWalking", true);

    }
}

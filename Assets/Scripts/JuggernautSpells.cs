using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautSpells : MonoBehaviour {

    public GameObject explosionAnimation;
    private GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        CastExplosion();
	}

    public void CastExplosion()
    {
        var seed = Random.Range(0, 100);

        if (seed > 95)
            Instantiate(explosionAnimation, player.transform.position, player.transform.rotation);
    }
}

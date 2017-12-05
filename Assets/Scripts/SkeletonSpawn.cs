using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawn : MonoBehaviour {


    public GameObject monster;
    public GameObject map;
    private int seed;
	
	void Update ()
    {
        TryToSpawnSkeleton();

	}

    private void Spawn()
    {
        Vector3 position = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f), 80, transform.position.z + Random.Range(-10.0f, 10.0f));  
        Instantiate(monster, position, Quaternion.identity);
    }

    public void TryToSpawnSkeleton()
    {
        seed = Random.Range(1, 100);

        if (seed > 97f)
            Spawn();
    }

}

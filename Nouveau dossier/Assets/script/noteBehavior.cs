using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {



    public Transform target;
    private Vector3 spawner;

	// Use this for initialization
	void Start () {
        spawner = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        // Gets a vector that points from the player's position to the target's.

        float distanceSpawnerMoine = Vector3.Distance(transform.position, spawner);
        float distanceObjetMoine = Vector3.Distance(transform.position, target.position);


        transform.audio.volume = (distanceSpawnerMoine - distanceObjetMoine) / distanceSpawnerMoine;

	}
}

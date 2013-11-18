using UnityEngine;
using System.Collections;

public class note : MonoBehaviour {


   // public GameObject target;
    public Vector3 spawner;
    public Transform target;
    public AnimationCurve ac;

    // Use this for initialization
    void Start()
    {

        spawner = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        // Gets a vector that points from the player's position to the target's.

        float distanceSpawnerMoine = Vector3.Distance(target.position, spawner);
        float distanceObjetMoine = Vector3.Distance(transform.position, target.position);


        transform.Translate(Vector3.left * Time.deltaTime);

        Debug.Log("distanceSpawnerMoine" + distanceSpawnerMoine);
        Debug.Log("distanceObjetMoine" + distanceObjetMoine);


        transform.audio.volume = ac.Evaluate(((distanceSpawnerMoine - distanceObjetMoine) / distanceSpawnerMoine)); 

       Debug.Log("volume" + transform.audio.volume);
    }
}

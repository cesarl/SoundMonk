using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    public GameObject note;
    public int nbNotes;
      
    public float tempsEntreSpawn;

    private float delay;
    private bool collided =false;
	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("test");
        collided = true;
        delay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            delay += Time.deltaTime;

            if (delay >= tempsEntreSpawn)
            {
                nbNotes--;
                Instantiate(note, transform.position, Quaternion.identity);
                delay = 0.0f;
            }
            if (nbNotes <= 0)
            {
                DestroyImmediate(this);
            }
        }

	}
}

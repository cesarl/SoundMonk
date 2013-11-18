using UnityEngine;
using System.Collections;

public class creerNote : MonoBehaviour {

    public Transform spawner;
    public Transform prefab;

	// Use this for initialization
	void Start () {
      Instantiate(prefab, spawner.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

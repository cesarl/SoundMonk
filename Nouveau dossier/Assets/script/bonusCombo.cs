using UnityEngine;
using System.Collections;

public class bonusCombo : MonoBehaviour {


    public float duree;

    private float debut;
	// Use this for initialization
	void Start () {
        
        debut = Time.time;
	}

	// Update is called once per frame
	void Update () {
        if(Time.time - debut > duree)
        DestroyImmediate(this);
	}
}

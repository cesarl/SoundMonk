using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float horizontalSpeed = 0.15f;

	private Transform	trans;
	private Vector2		dir;

	// Use this for initialization
	void Start () {
		trans = transform;
		dir = new Vector2(0.0f, -1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		trans.Translate(dir * horizontalSpeed * Time.deltaTime);
	}
}

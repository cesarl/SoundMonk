using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class MusicSpawner : MonoBehaviour
{
	public float[] times;
	public string[] name;

	private GameObject[]	spawners;
	private float			lastTime;

	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
		lastTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
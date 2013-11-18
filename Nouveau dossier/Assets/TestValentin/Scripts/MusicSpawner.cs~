using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class MusicSpawner : MonoBehaviour
{
	public float[] times;
	public GameObject[] instantiateModel;

	private GameObject[]	spawners;
	private float			lastTime;

	void Start ()
	{
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
		lastTime = 0.0f;
	}
	
	void Update ()
	{
		foreach (var it in times)
		{
			if (it > lastTime && it < Time.time)
			{
				GameObject obj = Instantiate(instantiateModel[0]) as GameObject;
				int idxSpawner = (int)Random.Range(0.0f, spawners.Length);
				obj.transform.position = spawners[idxSpawner].transform.position;
			}
		}
		lastTime = Time.time;
	}
}
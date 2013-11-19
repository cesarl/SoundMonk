using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
using UnityEditor;

public class Spawner : MonoBehaviour
{

	public GameObject note;

	public UnityEngine.Object filePattern;

	private float delay;
	private bool collided = false;
	private SpriteRenderer spriteRenderer;
	private GameObject camera;
	private int idx = 0;
	private int nbNotes;

	[Serializable]
	public class PatternNote
	{
		public float timeSpawn;
		public int type;
		public int damage;
	}

	public List<PatternNote> notes;

	// Use this for initialization
	void Start()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		camera = GameObject.FindGameObjectWithTag("MainCamera") as GameObject;
		loadPattern(AssetDatabase.GetAssetPath(filePattern));
	}


	// Update is called once per frame
	void Update()
	{
		GameObject go;

		if (notes == null)
			return;
		if (IsVisibleFrom(spriteRenderer, camera.camera) && !collided)
		{
			collided = true;
			delay = 0.0f;
		}

		if (collided)
		{
			delay += Time.deltaTime;
			if (delay >= notes[idx].timeSpawn)
			{
				go = Instantiate(note, transform.position, Quaternion.identity) as GameObject;
				go.GetComponent<noteSon>().typeSon = notes[idx].type;
				idx++;
			}
			if (idx >= notes.Count)
				DestroyImmediate(this);
		}
	}

	private bool IsVisibleFrom(this SpriteRenderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}

	private bool savePattern(string file)
	{
		XmlSerializer mySerializer = new XmlSerializer(typeof(List<PatternNote>));
		using (StreamWriter writer = new StreamWriter(file))
		{
			mySerializer.Serialize(writer, notes);
		}
		return true;
	}
	private bool loadPattern(string file)
	{
		XmlSerializer mySerializer = new XmlSerializer(typeof(List<PatternNote>));
		using (FileStream reader = new FileStream(file, FileMode.Open))
		{
			notes = mySerializer.Deserialize(reader) as List<PatternNote>;
		}
		Debug.Log(notes.Count);
		return true;
	}
}

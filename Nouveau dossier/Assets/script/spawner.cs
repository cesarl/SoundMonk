using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
using UnityEditor;

public class spawner : MonoBehaviour
{

	public GameObject note;

	public UnityEngine.Object filePattern;
	public AudioClip[] sounds;

	private float delay;
	private bool collided = false;
	private SpriteRenderer spriteRenderer;
	private Camera myCamera;
	private int idx = 0;
	private int nbNotes;
	private GameObject[] targets;

    BellScript mbs_bellScript;

	[Serializable]
	public class PatternNote
	{
		public float timeSpawn;
		public int type;
		public int damage;
		public int idTarget;
		public int idSound;
	}

	List<PatternNote> notes;

	// Use this for initialization
	void Start()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		myCamera = Camera.main;
		loadPattern(AssetDatabase.GetAssetPath(filePattern));
        mbs_bellScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BellScript>();
		targets = GameObject.FindGameObjectsWithTag("bellSlot");
	}


	// Update is called once per frame
	void Update()
	{
		GameObject go;

		if (notes == null)
			return;
		if (IsVisibleFrom(spriteRenderer, myCamera.camera) && !collided)
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
                mbs_bellScript.SendMessage("CalculateAccuracy");
				EnemyScript son = go.GetComponent<EnemyScript>();
				son.typeSon = notes[idx].type;
				son.damage = notes[idx].damage;
				son.target = targets[notes[idx].idTarget].transform;
				son.audio.clip = sounds[notes[idx].idSound];
				son.audio.Play();
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
		return true;
	}
}

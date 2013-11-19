using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
using UnityEditor;
public class SpawnerManager : MonoBehaviour {

	public GameObject[] spawners;
	public GameObject[] targets;
	public UnityEngine.Object filePattern;
	public GameObject[] spritesTab;

	private int idx = 0;
	private int nbNotes;
	private float delay;

	BellScript mbs_bellScript;

	public GameObject note;
    public GameObject noteInvis;


    public int soundType = 0;
	public AudioClip[] sounds;
    public AudioClip[] sounds2;


	[Serializable]
	public class PatternNote
	{
		public float timeSpawn;
		public int type;
		public int damage;
		public int idTarget;
		public int idSound;
		public int idSoundDestruction;
		public int idSprite;
		public float speed;
	}

	List<PatternNote> notes;

	// Use this for initialization
	void Start () {
		loadPattern(AssetDatabase.GetAssetPath(filePattern));
		mbs_bellScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BellScript>();


	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject go;

		if (notes == null)
			return;
		if (notes.Count != 0 && idx < notes.Count)
		{
			delay += Time.deltaTime;
			if (delay >= notes[idx].timeSpawn)
			{
                if (notes[idx].type == -1)
                {
                    Vector3 pos = spawners[notes[idx].idTarget].transform.position;
                    go = Instantiate(noteInvis, pos, Quaternion.identity) as GameObject;
                    EnemyScript son = go.GetComponent<EnemyScript>();
                    son.typeSon = notes[idx].type;
                    son.damage = notes[idx].damage;
                    son.target = targets[notes[idx].idTarget].transform;


                    if (soundType == 0)
                    {
                        son.audio.clip = sounds[notes[idx].idSound];
                    }
                    else
                        son.audio.clip = sounds2[notes[idx].idSound];

                    son.audio.Play();
                    son.audio.loop = true;
                    son.speed = notes[idx].speed;
                    son.sonDestruction = sounds[notes[idx].idSoundDestruction];
                    idx++;
                    
                }
                else
                {
					Vector3 pos = spawners[notes[idx].idTarget].transform.position;
					go = Instantiate(note, pos, Quaternion.identity) as GameObject;
					mbs_bellScript.SendMessage("CalculateAccuracy");
					EnemyScript son = go.GetComponent<EnemyScript>();
					son.typeSon = notes[idx].type;
					son.damage = notes[idx].damage;
					son.target = targets[notes[idx].idTarget].transform;
                   
                    if (soundType == 0)
                    {
                        son.audio.clip = sounds[notes[idx].idSound];
                    }
                    else
                        son.audio.clip = sounds2[notes[idx].idSound];


					son.audio.Play();
					son.speed = notes[idx].speed;
					son.sonDestruction = sounds[notes[idx].idSoundDestruction];
					son.sprites = spritesTab[notes[idx].idSprite].GetComponent<NoteSpriteTab>().sprites;
					idx++;
                }
			}
		}
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

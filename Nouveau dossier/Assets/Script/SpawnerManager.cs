using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
public class SpawnerManager : MonoBehaviour
{

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

    public bool mb_playerIsDead = false;

    public int soundType;
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
		public Color color = Color.white;
	}

	List<PatternNote> notes;

	// Use this for initialization
	void Start()
	{
		notes = XmlDeserializeFromString<List<PatternNote>>(filePattern.ToString());
		mbs_bellScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BellScript>();

      //  soundType = GameObject.Find("BonusSelector").GetComponent<BonusSelector>().son;
	}

	// Update is called once per frame
	void Update()
	{
        if (!mb_playerIsDead)
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
                        son.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        son.GetComponent<Renderer>().material.color = notes[idx].color;
                        idx++;
                    }
<<<<<<< HEAD
                }
            }
        }
=======
                    else
                        son.audio.clip = sounds2[notes[idx].idSound];


					son.audio.Play();
					son.speed = notes[idx].speed;
					son.sonDestruction = sounds[notes[idx].idSoundDestruction];
					son.sprites = spritesTab[notes[idx].idSprite].GetComponent<NoteSpriteTab>().sprites;
                    son.death = spritesTab[notes[idx].idSprite].GetComponent<NoteSpriteTab>().death;
					son.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					son.GetComponent<Renderer>().material.color = notes[idx].color;
					idx++;
				}
			}
		}
>>>>>>> 16de0ba0e411786deb3a7ce2f5070651427ae5fa
	}

	public object XmlDeserializeFromString(string objectData, Type type)
	{
		var serializer = new XmlSerializer(type);
		object result;

		using (TextReader reader = new StringReader(objectData))
		{
			result = serializer.Deserialize(reader);
		}
		return result;
	}

	public T XmlDeserializeFromString<T>(string objectData)
	{
		return (T)XmlDeserializeFromString(objectData, typeof(T));
	}
}

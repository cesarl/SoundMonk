using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public GameObject note;
	public int nbNotes;

	public float tempsEntreSpawn;
	public int[] codeNotes;


	private float delay;
	private bool collided = false;
	private SpriteRenderer spriteRenderer;
	private GameObject camera;
	private int cpt = 0;

	// Use this for initialization
	void Start()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		camera = GameObject.FindGameObjectWithTag("MainCamera") as GameObject;
		// codeNotes = new int[nbNotes];

	}


	// Update is called once per frame
	void Update()
	{
		GameObject go;

		if (IsVisibleFrom(spriteRenderer, camera.camera) && !collided)
		{
			collided = true;
			delay = 0.0f;
		//	Debug.Log("visible");
		}

		if (collided)
		{
			delay += Time.deltaTime;
			//Debug.Log("delay:" + delay);
			if (delay >= tempsEntreSpawn)
			{
			//	Debug.Log("in if");
				nbNotes--;
				go = Instantiate(note, transform.position, Quaternion.identity) as GameObject;
				go.GetComponent<noteSon>().typeSon = codeNotes[cpt];
				delay = 0.0f;
				cpt++;
			}
			if (nbNotes <= 0)
			{
			//	Debug.Log("delete");
				DestroyImmediate(this);
			}
		}
	}

	private bool IsVisibleFrom(this SpriteRenderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}

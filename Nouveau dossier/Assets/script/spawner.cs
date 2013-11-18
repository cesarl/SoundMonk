using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

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
	void Start ()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		camera = GameObject.FindGameObjectWithTag("MainCamera") as GameObject;
       // codeNotes = new int[nbNotes];

	}


    // Update is called once per frame
    void Update()
    {
        GameObject go;

        if (IsVisibleFrom(spriteRenderer, camera.camera))
        {
            collided = true;
            delay = 0.0f;
        }
       
        if (collided)
        {
            delay += Time.deltaTime;

            if (delay >= tempsEntreSpawn)
            {

                nbNotes--;
               go = Instantiate(note, transform.position, Quaternion.identity) as GameObject;
               go.GetComponent<noteSon>().typeSon = codeNotes[cpt];

                delay = 0.0f;
                cpt++;
            }
            if (nbNotes <= 0)
            {
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

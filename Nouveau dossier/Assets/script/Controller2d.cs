using UnityEngine;
using System.Collections;

public class Controller2d : MonoBehaviour
{

	private Transform trans;
	private SpriteRenderer spriteRenderer;
	private int idxIdle;
	private float timeIdle;

	public float horizontalSpeed = 1.0f;
    public float radius = 3.0f;
	public float timeBetweenIdle = 0.1f;
	public Sprite[] idleSprites;
	public Sprite leftSprite;
	public Sprite rightSprite;

	// Use this for initialization
	void Start () {
		trans = transform;
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		idxIdle = 0;
		timeIdle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	//	Vector2	dir = new Vector2(0.0f, 0.0f);
		/*if (Input.GetKey("d"))
		{
            dir += new Vector2(1.0f, 0.0f) * horizontalSpeed;
			spriteRenderer.sprite = rightSprite;
		}
		else if (Input.GetKey("a") || Input.GetKey("q"))
		{
            dir += new Vector2(-1.0f, 0.0f) * horizontalSpeed;
			spriteRenderer.sprite = leftSprite;
		}
		else
			spriteRenderer.sprite = idleSprites[idxIdle];*/

		//trans.Translate(dir * Time.deltaTime);

       /* Debug.Log("test");
        for(int i =0; i< GameObject.FindGameObjectsWithTag("note").Length ;i++){
            Debug.Log("test2");
            Destroy(GameObject.FindGameObjectsWithTag("note")[i]);

            GameObject.FindGameObjectsWithTag("note")[i].transform.Translate(-100.0f * dir * Time.deltaTime);
        }*/

//
	//	trans.Translate(dir * Time.deltaTime);

       /* Debug.Log("test");
        for(int i =0; i< GameObject.FindGameObjectsWithTag("note").Length ;i++){
            Debug.Log("test2");
            Destroy(GameObject.FindGameObjectsWithTag("note")[i]);

            GameObject.FindGameObjectsWithTag("note")[i].transform.Translate(-100.0f * dir * Time.deltaTime);
        }*/


       /* Debug.Log("test");
        for(int i =0; i< GameObject.FindGameObjectsWithTag("note").Length ;i++){
            Debug.Log("test2");
            Destroy(GameObject.FindGameObjectsWithTag("note")[i]);

            GameObject.FindGameObjectsWithTag("note")[i].transform.Translate(-100.0f * dir * Time.deltaTime);
        }*/

		timeIdle += Time.deltaTime;

		if (timeIdle > timeBetweenIdle)
		{
			timeIdle = 0.0f;
			idxIdle = (idxIdle + 1) % idleSprites.Length;
		}
	}
}

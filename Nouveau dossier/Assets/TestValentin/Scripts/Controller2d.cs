using UnityEngine;
using System.Collections;

public class Controller2d : MonoBehaviour
{

	private Transform trans;
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider;
	public float verticalSpeed = 1.0f;
	public float horizontalSpeed = 0.05f;

	// Use this for initialization
	void Start () {
		trans = transform;
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2	dir = new Vector2(0.0f, 0.0f);
		//input
		if (Input.GetKey("right"))
			dir += new Vector2(1.0f, 0.0f) * verticalSpeed;
		if (Input.GetKey("left"))
			dir += new Vector2(-1.0f, 0.0f) * verticalSpeed;
		dir += new Vector2(0.0f, 1.0f) * horizontalSpeed;
		trans.Translate(dir * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("test");
	}
}

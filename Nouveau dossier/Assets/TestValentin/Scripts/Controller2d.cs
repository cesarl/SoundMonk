using UnityEngine;
using System.Collections;

public class Controller2d : MonoBehaviour
{

	private Transform trans;
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider;
	private int idxIdle;
	private float timeIdle;

	public float verticalSpeed = 1.0f;
	//public float horizontalSpeed = 0.05f;
    public float radius = 3.0f;
	public float timeBetweenIdle = 0.1f;
	public Sprite[] idleSprites;
	public Sprite leftSprite;
	public Sprite rightSprite;

	// Use this for initialization
	void Start () {
		trans = transform;
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
		idxIdle = 0;
		timeIdle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2	dir = new Vector2(0.0f, 0.0f);
		//input
		if (Input.GetKey("right"))
		{
			dir += new Vector2(1.0f, 0.0f) * verticalSpeed;
			spriteRenderer.sprite = rightSprite;
		}
		else if (Input.GetKey("left"))
		{
			dir += new Vector2(-1.0f, 0.0f) * verticalSpeed;
			spriteRenderer.sprite = leftSprite;
		}
		else
			spriteRenderer.sprite = idleSprites[idxIdle];
		//dir += new Vector2(0.0f, 1.0f) * horizontalSpeed;
		trans.Translate(dir * Time.deltaTime);
		timeIdle += Time.deltaTime;
		if (timeIdle > timeBetweenIdle)
		{
			timeIdle = 0.0f;
			idxIdle = (idxIdle + 1) % idleSprites.Length;
		}
	}
}

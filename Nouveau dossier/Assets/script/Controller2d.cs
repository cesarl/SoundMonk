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
	public Sprite[] waveAnim;

	private bool inWaveAnimation;
	private GameObject animObj;
	private SpriteRenderer animRenderer;

	// Use this for initialization
	void Start () {
		trans = transform;
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		idxIdle = 0;
		timeIdle = 0.0f;
		animObj = GameObject.Find("AnimBomb");
		animRenderer = animObj.GetComponent<SpriteRenderer>();
		startWaveAnim();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (inWaveAnimation)
			animRenderer.sprite = waveAnim[idxIdle];
		else
			spriteRenderer.sprite = idleSprites[idxIdle];
		timeIdle += Time.deltaTime;
		if (timeIdle > timeBetweenIdle)
		{
			timeIdle = 0.0f;
			if (inWaveAnimation)
			{
				idxIdle = (idxIdle + 1) % waveAnim.Length;
				if (idxIdle == 0)
					stopWaveAnim();
			}
			else
				idxIdle = (idxIdle + 1) % idleSprites.Length;
		}
	}

	public void startWaveAnim()
	{
		inWaveAnimation = true;
		idxIdle = 0;
		animObj.SetActive(true);
		renderer.enabled = false;
	}

	public void stopWaveAnim()
	{
		inWaveAnimation = false;
		animObj.SetActive(false);
		renderer.enabled = true;
	}
}

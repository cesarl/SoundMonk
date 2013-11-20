using UnityEngine;
using System.Collections;

public class Controller2d : MonoBehaviour
{

	private Transform trans;
	private SpriteRenderer spriteRenderer;
	private int idxIdle;
	private float timeIdle;

    public bool mb_playerIsDead = false;

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
<<<<<<< HEAD
	void Update () {
        if (!mb_playerIsDead)
        {
            /*Vector2	dir = new Vector2(0.0f, 0.0f);

            if (Input.GetKey("d"))
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
                spriteRenderer.sprite = idleSprites[idxIdle];

            trans.Translate(dir * Time.deltaTime);*/

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
=======
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
>>>>>>> f98ae83d4e34622834d6e156bf4c8464d7b3f803
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

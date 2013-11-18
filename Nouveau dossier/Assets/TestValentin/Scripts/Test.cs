using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

	SpriteRenderer spriteRenderer;
	public Sprite[] idleSprites;
	public Sprite leftSprite;
	public Sprite rightSprite;
	// Use this for initialization
	void Start () {
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.sprite = Resources.Load<Sprite>("monk_idle1");
	}
}

using UnityEngine;
using System.Collections;

public class WaveAnimation : MonoBehaviour {

	public Sprite[] idleSprites;
    private SpriteRenderer spriteRenderer;
    int id = 0;
    float time = 0;

	// Use this for initialization
	void Start () {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 0.06f)
        {
			id = (id + 1) % idleSprites.Length;
            time = 0;
        }
        spriteRenderer.sprite = idleSprites[id];

	}
}

using UnityEngine;
using System.Collections;

public class MultiplicatorIcon : MonoBehaviour {

	public Sprite[] sprites;
    private SpriteRenderer _rend;

	// Use this for initialization
	void Start () {
        _rend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateIcon(int multiplicator)
    {
        if (multiplicator == 0)
        {
            _rend.sprite = null;
        }
        else if (multiplicator == 2)
        {
            _rend.sprite = sprites[0];
        }
        else if (multiplicator == 5)
        {
            _rend.sprite = sprites[1];
        }
        else if (multiplicator == 10)
        {
            _rend.sprite = sprites[2];
        }
    }
}

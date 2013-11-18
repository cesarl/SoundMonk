using UnityEngine;
using System.Collections;

public class EnemyScript
    : MonoBehaviour {

    public float speed = 1.0f;
    GameObject _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, _player.transform.position, speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player")
            Destroy(this.gameObject);
    }
}

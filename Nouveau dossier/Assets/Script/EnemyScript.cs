using UnityEngine;
using System.Collections;

public class EnemyScript
    : MonoBehaviour
{

    public float speed = 3.0f;
    public int handleDistance = 3;
    public Transform target;
	public int typeSon;
	public int damage;

    float _time;
    Vector3 _start;
	GameObject player;
	float offsetX;

    public AnimationCurve curve;

    // Use this for initialization
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
        _time = 0;
        _start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

		this.transform.position = Vector2.Lerp(_start,
											   player.transform.position,
											   _time / speed);
			
    }

}

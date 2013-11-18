using UnityEngine;
using System.Collections;

public class EnemyScript
    : MonoBehaviour {

    public float speed = 10.0f;
    GameObject _player;
    Vector3 _handle1;
    Vector3 _handle2;
    float _time;
    Vector3 _start;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player");
        _handle1 = transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
        _handle2 = _handle1 + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
        _time = 0;
        _start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = Vector3.MoveTowards(this.transform.position, _player.transform.position, speed * Time.deltaTime);
        _time += Time.deltaTime;
        Debug.Log(_time / speed);
        this.transform.position = CalculateBezierPoint(_time / speed, _start, _handle1, _handle2, _player.transform.position);
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player")
            Destroy(this.gameObject);
    }

Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
{
    float u;
    float uu;
    float uuu;
    float tt;
    float ttt;
    Vector3 p;

    u = 1 - t;
    uu = u * u;
    uuu = uu * u;
    tt = t * t;
    ttt = tt * t;
    p = uuu * p0; //first term of the equation
    p += 3 * uu * t * p1; //second term of the equation
    p += 3 * u * tt * p2; //third term of the equation
    p += ttt * p3; //fourth term of the equation
    return p;
}


}

﻿using UnityEngine;
using System.Collections;

public class EnemyScript
    : MonoBehaviour
{

    public float speed = 3.0f;
    public int handleDistance = 3;
    public Transform target;
	public int typeSon;
	public int damage;

    Vector3 _handle1;
    Vector3 _handle2;
    float _time;
    Vector3 _start;
	bool _rushToPlayer;
	GameObject player;
	float offsetX;

    public AnimationCurve curve;

    // Use this for initialization
    void Start()
    {
        float angle = getAngle(transform.position, target.position);

        int[] rangeX = { -handleDistance, handleDistance };
        int[] rangeY = { -handleDistance, handleDistance };

		player = GameObject.FindGameObjectWithTag("Player");
		_rushToPlayer = false;
		offsetX = target.position.x - player.transform.position.x;

        if ((angle > 0 && angle < 90))
        {
            rangeY[0] = -handleDistance;
            rangeY[1] = 0;
        }

        if (angle > 90 && angle < 180)
        {
            rangeX[0] = -handleDistance;
            rangeX[1] = 0;
        }
        if ((angle > 180 && angle < 270))
        {
            rangeY[0] = 0;
            rangeY[1] = handleDistance;
        }
        if (angle > 270 && angle <= 360)
        {
            rangeX[0] = 0;
            rangeX[1] = handleDistance;
        }

        _handle1 = transform.position + new Vector3(Random.Range(rangeX[0], rangeX[1]), Random.Range(rangeY[0], rangeY[1]), 0);
        _handle2 = _handle1 + new Vector3(Random.Range(rangeX[0], rangeX[1]), Random.Range(rangeY[0], rangeY[1]), 0);
        _time = 0;
        _start = transform.position;

        Vector3 t = new Vector3(_handle2.x, _handle2.y, _handle2.z);
        angle = getAngle(t, target.position);

        int d = (int)angle / 60;
        d *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
		/*if (!_rushToPlayer)
		{
			Vector2 dir = Vector2.zero;

			if (typeSon == 0)
				UpdateType0();
			else if (typeSon == 1)*/
				UpdateType1();
			/*else if (typeSon == 2)
				UpdateType2();
			float distance = Vector2.Distance(transform.position, target.position);
			if (distance < 0.1f)
				_rushToPlayer = true;
		}
		else
			this.transform.position = Vector2.Lerp(this.transform.position,
												   player.transform.position,
												   Time.deltaTime * 10.0f);*/
			
    }

	void UpdateType0()
	{
		this.transform.position = CalculateBezierPoint(_time / speed, _start, _handle1,
														   _handle2, target.position);
		Debug.Log("Here");
	}

	void UpdateType1()
	{
		/*Vector2 dir = Vector2.zero;
		if (this.transform.position.y - target.transform.position.y < 5.0f &&
			this.transform.position.y - target.transform.position.y > 2.0f)
		{
			if (offsetX < 0 && transform.position.x > target.transform.position.x)
				dir += new Vector2(-1.0f, 0.0f);
			else if (offsetX > 0 && transform.position.x < target.transform.position.x)
				dir += new Vector2(1.0f, 0.0f);
			if (dir != Vector2.zero)
			{
				this.transform.Translate(dir * Time.deltaTime * speed * 2);
				Debug.Log(dir);
			}
		}
		if (dir == Vector2.zero)
		{*/
			this.transform.position = Vector2.Lerp(this.transform.position,
												   target.transform.position,
												   Time.deltaTime);
			//Debug.Log("lerp : " + dir);
		//}
	}

	void UpdateType2()
	{
		//type code here
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

    float getAngle(Vector3 t1, Vector3 pos)
    {
        float dot = Vector3.Dot(t1, pos);
        dot = dot / (t1.magnitude * pos.magnitude);
        float acos = Mathf.Acos(dot);
        float angle = acos * 180 / Mathf.PI;
        return angle;
    }

}
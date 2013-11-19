using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bonus : MonoBehaviour
{
	void Start () {
	}
	
	void Update () {
	
	}
}

public class BonusShield : Bonus
{
    public float duration = 7.0f;
    public float radius = 2.0f;
    private float _time;

    void Start () {
        _time = 0.0f;
	}
	
	void Update () {
        _time += Time.deltaTime;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("note");
        foreach(GameObject e in enemies)
        {
            Debug.Log(Vector2.Distance(e.transform.position, GameObject.FindWithTag("Player").transform.position));
            if (Vector2.Distance(e.transform.position, GameObject.FindWithTag("Player").transform.position) <= radius)
                Destroy(e);
        }

        if (_time >= duration)
        {
            Destroy(gameObject.GetComponent<BonusShield>());
        }
	}
}


public class BonusWave : Bonus
{
    void Start () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("note");
        foreach(GameObject e in enemies)
        {
            Destroy(e);
        }
	}
	
	void Update () {
        Destroy(gameObject.GetComponent<BonusWave>());
	}
}


public class BonusManager : MonoBehaviour {

    private bool shield = false; 
    private bool wave = false; 
    private GameObject bell;
    private int _lastPerfect = 0;

	void Start () {
        bell = GameObject.Find("Bell");
	}
	
	void Update () {
        BellScript b = bell.GetComponent<BellScript>();

        if (b.perfectCombo == 7 && _lastPerfect != b.perfectCombo)
        {
            shield = true;
        }

        if (b.perfectCombo == 10 && _lastPerfect != b.perfectCombo)
        {
            wave = true;
        }

        _lastPerfect = b.perfectCombo;
        updateInput();
	}

    void updateInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (shield)
            {
                gameObject.AddComponent<BonusShield>();
                shield = false;
            }
            else if (wave)
            {

            }
        }
    }
}


﻿using UnityEngine;
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
        GameObject o = Instantiate(Resources.Load("Shield"), GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Player").transform.rotation) as GameObject;
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
    private float t = 0.0f;

    void Start () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("note");
        foreach(GameObject e in enemies)
        {
            Destroy(e);
        }
        
        GameObject o = Instantiate(Resources.Load("Wave"), GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Player").transform.rotation) as GameObject;
	}
	
	void Update () {
        t += Time.deltaTime;
        if (t > 0.5f)
        {
            Destroy(GameObject.FindWithTag("wave"));
            Destroy(gameObject.GetComponent<BonusWave>());
        }
	}
}


public class BonusManager : MonoBehaviour {

    public bool shield = false;
    public bool wave = false; 
    public GameObject bell;
    private int _lastPerfect = 0;

    public GameObject icon;
    public Sprite shieldIcon;
    public Sprite waveIcon;

    public string typeBonus;

	void Start () {
        typeBonus = GameObject.Find("BonusSelector").GetComponent<BonusSelector>().bonus;
	}
	
	void Update () {
        BellScript b = bell.GetComponent<BellScript>();

        if (b.perfectCombo == 10 && _lastPerfect != b.perfectCombo)
        {
            shield = true;
            icon.GetComponent<SpriteRenderer>().sprite = shieldIcon;
        }

        if (b.perfectCombo == 2 && _lastPerfect != b.perfectCombo)
        {
            wave = true;
            icon.GetComponent<SpriteRenderer>().sprite = waveIcon;
        }

        if (b.perfectCombo < 2)
        {
            GameObject.Find("multiplicator").GetComponent<MultiplicatorIcon>().updateIcon(0);
        }
        else if (b.perfectCombo < 5)
        {
            GameObject.Find("multiplicator").GetComponent<MultiplicatorIcon>().updateIcon(2);
        }
        else if (b.perfectCombo < 9)
        {
            GameObject.Find("multiplicator").GetComponent<MultiplicatorIcon>().updateIcon(5);
        }
        else
        {
            GameObject.Find("multiplicator").GetComponent<MultiplicatorIcon>().updateIcon(10);
        }


        _lastPerfect = b.perfectCombo;
        updateInput();
	}

    void updateInput()
    {
      /*  if (Input.GetKeyDown(KeyCode.E))
        {
            if (shield)
            {
                gameObject.AddComponent<BonusShield>();
                icon.GetComponent<SpriteRenderer>().sprite = null;
                shield = false;
            }
            else if (wave)
            {
                wave = false;
                icon.GetComponent<SpriteRenderer>().sprite = null;
                gameObject.AddComponent<BonusWave>();
            }
        }*/
    }
}


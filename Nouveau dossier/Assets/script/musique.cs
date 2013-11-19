using UnityEngine;
using System.Collections;

public class musique : MonoBehaviour {

    public AudioClip musiqueNormale;
    public AudioClip musiquePleinEnemis;

    public int nbEnemisModeRapide;
    public int nbEnemisModeLent;

    public float volumeMusique;


    private bool fadeout;
    private bool achange = false;
	// Use this for initialization
	void Start () {
        audio.clip = musiqueNormale;
        audio.loop = true;
        audio.volume = volumeMusique;
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {

        if (fadeout)
        {
            audio.volume -= Time.deltaTime* 5f * 0.1f;
        }

        if (achange == false && GameObject.FindGameObjectsWithTag("note").Length >= nbEnemisModeRapide)
        {
            fadeout = true;
            achange = true;
        }

        if (achange == true && GameObject.FindGameObjectsWithTag("note").Length <= nbEnemisModeLent)
        {
            fadeout = true;
            achange = false;
        }


        if (audio.volume <= 0.1 && achange == true)
        {
            fadeout = false;
            audio.clip = musiquePleinEnemis;
            audio.loop = true;
            audio.volume = volumeMusique;
            audio.Play();
        }

        if (audio.volume <= 0.1 && achange == false)
        {
            fadeout = false;
            audio.clip = musiqueNormale;
            audio.loop = true;
            audio.volume = volumeMusique;
            audio.Play();
        }



	}







}

using UnityEngine;
using System.Collections;

public class musique : MonoBehaviour {

    public AudioClip musiqueVilleNormale;
    public AudioClip musiqueVillePleinEnemis;

    public AudioClip musiqueCielNormale;
    public AudioClip musiqueCielPleinEnemis;

    public AudioClip musiqueEspaceNormale;
    public AudioClip musiqueEspacePleinEnemis;

    public int nbEnemisModeRapide;
    public int nbEnemisModeLent;

    public int etat = 0;

    public float tempsTotal;


    public float volumeMusique;


    private bool fadeout;
    private bool achange = false;
	// Use this for initialization
	void Start () {
        audio.clip = musiqueVilleNormale;
        audio.loop = true;
        audio.volume = volumeMusique;
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {

       // if(etat


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

            switch(etat){
                case 0: audio.clip = musiqueVillePleinEnemis; break;
                case 1: audio.clip = musiqueCielPleinEnemis; break;
                case 2: audio.clip = musiqueEspacePleinEnemis; break;
                 }

            audio.loop = true;
            audio.volume = volumeMusique;
            audio.Play();
        }

        if (audio.volume <= 0.1 && achange == false)
        {
            fadeout = false;
            switch (etat)
            {
                case 0: audio.clip = musiqueVilleNormale; break;
                case 1: audio.clip = musiqueCielNormale; break;
                case 2: audio.clip = musiqueEspaceNormale; break;
            }

            audio.loop = true;
            audio.volume = volumeMusique;
            audio.Play();
        }

        GameObject.Find("Main Camera").GetComponent<AudioLowPassFilter>().cutoffFrequency =  (1- ( 
            GameObject.Find("Player").GetComponent<comportementPerso>().vie/GameObject.Find("Player").GetComponent<comportementPerso>().vieMax)) * (float)(-5000.0) + 5000.0f ;
        
        GameObject.Find("Main Camera").GetComponent<AudioReverbFilter>().reverbLevel = ((1 - (
            GameObject.Find("Player").GetComponent<comportementPerso>().vie / GameObject.Find("Player").GetComponent<comportementPerso>().vieMax)) * 9000.0f)-7000;
         
        

	}







}

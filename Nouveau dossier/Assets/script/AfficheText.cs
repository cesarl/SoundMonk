using UnityEngine;
using System.Collections;

public class AfficheText : MonoBehaviour
{

    public string[] textAPop;
    public float[] TempsAPop;
    public float[] dureeText;


    private float temps;

    private int cpt = 0;
    private bool affiche = false;
    private float tempsDelta;

    // Use this for initialization
    void Start()
    {
        temps = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            Time.timeScale = 1;


        temps += Time.deltaTime;

        if (affiche == false && cpt < TempsAPop.Length && TempsAPop[cpt] <= temps)
        {
            affiche = true;
            Time.timeScale = 0;
            tempsDelta = 0.0f;
        }

    }


    void OnGUI()
    {
  if (Input.GetKeyDown("space"))
            Time.timeScale = 1;
            

    if(affiche == true)
    {
        tempsDelta += Time.deltaTime;
     //   affiche = false;
     //   Debug.Log("tracacce");
        GUI.Label(new Rect(Screen.width / 4, Screen.height / 2, 150, 150), textAPop[cpt]);
       
        if (tempsDelta >= dureeText[cpt])
        { affiche = false; cpt++; }
     }

    }

}

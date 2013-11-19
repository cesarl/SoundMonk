using UnityEngine;
using System.Collections;

public class comportementPerso : MonoBehaviour
{

    public float vieMax;
    public float vie;
    public int viePerduParObstacle;

    public Texture2D lifeBarFull;
    public Texture2D lifeBarEmpty;


    // Use this for initialization
    void Start()
    {
        vie = vieMax;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "obstacle")
        {
            vie -= viePerduParObstacle;
            Debug.Log("vie :" + vie);
        }
    }

    */


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject);
            vie -= viePerduParObstacle;// Mathf.Lerp(vie, vie - viePerduParObstacle, Time.deltaTime * 100);
            Debug.Log("vie :" + vie);
         //   majBarreDeVie();
        }

        if (collision.gameObject.tag == "note")
        {
			noteSon note = collision.gameObject.GetComponent<noteSon>() as noteSon;
			int hit = note.hit;
            Destroy(collision.gameObject);
			vie -= hit; // Mathf.Lerp(vie, vie - viePerduParNote, Time.deltaTime*100);
            Debug.Log("vie :" + vie);
          //  majBarreDeVie();
        }
    }


    void OnGUI()
    {

        GUI.DrawTexture(new Rect(0, 0, lifeBarEmpty.width, lifeBarEmpty.height), lifeBarFull);

        GUI.DrawTexture(new Rect(0, 0, lifeBarEmpty.width, lifeBarFull.height *  ((100-vie) / vieMax)), lifeBarEmpty);
      
    }

 /*   void majBarreDeVie()
    {
        GameObject objet = GameObject.Find("UbiGaCha_Life_Bar");
        objet.transform.localScale = new  Vector3(1.0f, (float) vie/100.0f, 1.0f);
    }
    */

}

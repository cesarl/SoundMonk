using UnityEngine;
using System.Collections;

public class detruitclick : MonoBehaviour {

    public int bonusVie = 5;
    public float tempsVie = 5;

    private Vector3 vector3;


    private Vector3 cible;
	// Use this for initialization
	void Start () {
        cible = new Vector3(Random.Range(transform.position.x - 5, transform.position.x + 5), Random.Range(transform.position.y - 10, 0), 0);
	}
	
    
	// Update is called once per frame
	void Update () {
        
        if(Vector3.Distance(  transform.position,cible)<0.1){
              cible = new Vector3(Random.Range(transform.position.x - 5, transform.position.x + 5), Random.Range(transform.position.y - 10, 0), 0);
        }
        else
        transform.position=  Vector3.Lerp(transform.position, cible,Time.deltaTime / 3);

        tempsVie -= Time.deltaTime;
        if (tempsVie < 0) Destroy(this.gameObject);

	}


    void OnMouseDown()
    {
        Debug.Log("Test");

        GameObject.Find("Player").GetComponent<comportementPerso>().vie += bonusVie;

        if (GameObject.Find("Player").GetComponent<comportementPerso>().vie > GameObject.Find("Player").GetComponent<comportementPerso>().vieMax)
            GameObject.Find("Player").GetComponent<comportementPerso>().vie = GameObject.Find("Player").GetComponent<comportementPerso>().vieMax;

        GameObject.Find("Bell").GetComponent<BellScript>().nbPerfect++;

            Destroy(this.gameObject);
      
    }
        
}

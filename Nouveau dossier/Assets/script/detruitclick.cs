using UnityEngine;
using System.Collections;

public class detruitclick : MonoBehaviour {

    public int bonusVie;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        Debug.Log("dbbt!");

        GameObject.Find("Player").GetComponent<comportementPerso>().vie += bonusVie;

        if (GameObject.Find("Player").GetComponent<comportementPerso>().vie > GameObject.Find("Player").GetComponent<comportementPerso>().vieMax)
            GameObject.Find("Player").GetComponent<comportementPerso>().vie = GameObject.Find("Player").GetComponent<comportementPerso>().vieMax;

            Destroy(this.gameObject);
      
    }
        
}

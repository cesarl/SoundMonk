using UnityEngine;
using System.Collections;

public class spawnBonus : MonoBehaviour {

    public Transform bonusApop;
     

    private float temps;

    public float[] TempsAPop;
    private int cpt = 0;

	// Use this for initialization
	void Start () {
        temps = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        temps += Time.deltaTime;
    
        if(cpt <TempsAPop.Length &&  TempsAPop[cpt]<=temps){
            Vector3 vect =  new Vector3( (float)( GameObject.Find("Main Camera").transform.position.x + Random.Range(-3,3))  ,
                (GameObject.Find("Main Camera").transform.position.y + Random.Range(2,3))
                ,-1);
            Instantiate(bonusApop, vect, Quaternion.identity);
             cpt++;
        }


    }

    //    TempsAPop
	}


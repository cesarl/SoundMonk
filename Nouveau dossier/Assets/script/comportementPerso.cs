using UnityEngine;
using System.Collections;

public class comportementPerso : MonoBehaviour
{

    public int vie;
    public int viePerduParObstacle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "obstacle")
        {
            vie -= viePerduParObstacle;

        }
    }



}

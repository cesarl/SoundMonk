using UnityEngine;
using System.Collections;

public class comportementPerso : MonoBehaviour
{

    public float vieMax;
    public float vie;
    public int viePerduParObstacle;

    public Texture2D lifeBarFull;
    public Texture2D lifeBarEmpty;

    public Transform mt_bellTransform;

    float mf_score = 0;
    float mf_accuracy = 0;

    BellScript mt_bellScript;

    // Use this for initialization
    void Start()
    {
        vie = vieMax;
        mt_bellScript = mt_bellTransform.GetComponent<BellScript>();
    }

    // Update is called once per frame
    void Update()
    {
        mf_score = mt_bellScript.mf_score;
        mf_accuracy = mt_bellScript.mf_currentAccuracy;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject);
            vie -= viePerduParObstacle;
            Debug.Log("vie :" + vie);
        }

        if (collision.gameObject.tag == "note")
        {
            Destroy( collision.gameObject);
            vie -= viePerduParNote;
            Debug.Log("vie :" + vie);
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 40, lifeBarEmpty.width, lifeBarEmpty.height), lifeBarFull);

        GUI.DrawTexture(new Rect(0, 40, lifeBarEmpty.width, lifeBarFull.height *  ((100-vie) / vieMax)), lifeBarEmpty);

        GUILayout.Label("Score : " + mf_score);
        GUILayout.Space(-10);
        GUILayout.Label("Précision : " + (mf_accuracy * 100).ToString("F") + "%");

    }

}

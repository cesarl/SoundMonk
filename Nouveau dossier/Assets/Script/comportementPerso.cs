using UnityEngine;
using System.Collections;

public class comportementPerso : MonoBehaviour
{

    public float vieMax;
    public float vie;
    public int viePerduParObstacle;
    public int viePerduParNote;

    public AudioClip sondegatRecu;

    public Texture2D lifeBarFull;
    public Texture2D lifeBarEmpty;
    public Texture2D lifeBarBack;

    public Transform mt_bellTransform;
    public Background mg_spawnGO;
    public Texture2D mt_textureGameOver;

    float mf_score = 0;
    float mf_accuracy = 0;

    bool mb_playerIsDead = false;

    BellScript mgs_bellScript;
    SpawnerManager msm_spawnerManager;
    Controller2d mc_controller2d;

    // Use this for initialization
    void Start()
    {
        vie = vieMax;
        mgs_bellScript = mt_bellTransform.GetComponent<BellScript>();
        msm_spawnerManager = GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>();
        mc_controller2d = GameObject.Find("Player").GetComponent<Controller2d>();
    }

    // Update is called once per frame
    void Update()
    {
        mf_score = mgs_bellScript.mf_score;
        mf_accuracy = mgs_bellScript.mf_currentAccuracy;
        CheckLife();
    }

    void CheckLife()
    {
        if (vie <= 0)
        {
            mg_spawnGO.verticalSpeed = 0;
            this.GetComponent<Controller2d>().idleSprites = null;
            foreach (GameObject e in GameObject.FindGameObjectsWithTag("note"))
            {
                Destroy(e);
            }
            msm_spawnerManager.mb_playerIsDead = true;
            mgs_bellScript.mb_playerIsDead = true;
            mc_controller2d.mb_playerIsDead = true;
            mb_playerIsDead = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {

        //   Debug.Log("vie :" + vie);
        /* if (collision.gameObject.tag == "obstacles")
         {
             Destroy(collision.gameObject);
             vie -= viePerduParObstacle;
         //    Debug.Log("vie :" + vie);
         }*/

        if (collision.gameObject.tag == "note" && !collision.gameObject.GetComponent<EnemyScript>().toKill)
        {
            GameObject.Find("Bell").GetComponent<BellScript>().SendMessage("CalculateAccuracy");
            vie -= collision.gameObject.GetComponent<EnemyScript>().damage;
            if (sondegatRecu != null)
            {
                audio.clip = sondegatRecu;
                audio.volume = 1.0f;
                audio.Play();
            }
            Destroy(collision.gameObject);
            // Debug.Log("vie :" + vie);
        }
    }

    void OnGUI()
    {
        if (!mb_playerIsDead)
        {
            GUI.DrawTexture(new Rect(0, 40, lifeBarBack.width, 0.3f * lifeBarBack.height), lifeBarBack);
            GUI.DrawTexture(new Rect(0, 40, lifeBarEmpty.width, 0.3f * lifeBarEmpty.height * ((vie) / vieMax)), lifeBarFull);
            GUI.DrawTexture(new Rect(0, 40, lifeBarEmpty.width, 0.3f * lifeBarFull.height), lifeBarEmpty);

            GUI.DrawTexture(new Rect(0, 40, lifeBarBack.width, 0.3f * lifeBarBack.height), lifeBarBack);
            GUI.DrawTexture(new Rect(0, 40, lifeBarEmpty.width, 0.3f * lifeBarEmpty.height * ((vie) / vieMax)), lifeBarFull);

            GUI.DrawTexture(new Rect(0, 40, lifeBarEmpty.width, 0.3f * lifeBarFull.height), lifeBarEmpty);

            //bombe : 7
            //shield : 7

            GUI.DrawTexture(new Rect(Screen.width - lifeBarBack.width, 40, lifeBarBack.width, 0.3f * lifeBarBack.height), lifeBarBack);

            // Debug.Log(GameObject.Find("Bell").GetComponent<BellScript>().nbPerfect);

            GUI.DrawTexture(new Rect(Screen.width - lifeBarBack.width, 40, lifeBarEmpty.width, 0.3f * lifeBarEmpty.height *
                ((GameObject.Find("Bell").GetComponent<BellScript>().nbPerfect / 7.0f))), lifeBarFull);
            GUI.DrawTexture(new Rect(Screen.width - lifeBarBack.width, 40, lifeBarEmpty.width, 0.3f * lifeBarFull.height), lifeBarEmpty);
            GUILayout.Label("Score : " + mf_score);
            GUILayout.Space(-10);
            GUILayout.Label("Concentration : " + (mf_accuracy * 100).ToString("F") + "%");
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - mt_textureGameOver.width / 2, Screen.height / 2 - mt_textureGameOver.height / 2, mt_textureGameOver.width, mt_textureGameOver.height), mt_textureGameOver);
        }
    }
}

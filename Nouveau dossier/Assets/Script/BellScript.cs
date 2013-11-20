using UnityEngine;
using System.Collections;

public class BellScript : MonoBehaviour
{
    public Transform player;

    public float mf_score = 0;
    public float mf_accuracy = 0;
    public float mf_currentAccuracy = 1;
    public float mf_smoothDamping = 20;
    public float mf_bellColorationTime = 0.1f;

    public bool mb_playerIsDead = false;

    public Transform[] mt_bellWantedTransformPos;
    public Transform combo2;

    public int maxBonus = 7;

    public Sprite[] idleSprites;

    int mi_indexWantedTransformPos = 0;

    float mf_bellActionTime;
    float mf_instantiateSongCount = 0;
    float timeIdle;
    float timeBetweenIdle = 0.1f;
    public int perfectCombo = 0;
    public int nbPerfect =0;

    int idxIdle;

    Transform mt_wantedTransformPosition;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        timeIdle = 0.0f;
        idxIdle = 0;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        mt_wantedTransformPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mb_playerIsDead)
        {
            GetInput();
            MoveBell();
            ApplySpriteRenderer();
        }
        GetInput();
        MoveBell();
        ApplySpriteRenderer();

        if (nbPerfect > maxBonus)
        {
            nbPerfect = 0;

            if (GameObject.Find("Player").GetComponent<BonusManager>().typeBonus.Equals("Shield"))
            {
                GameObject.Find("Player").GetComponent<BonusManager>().shield = true;
            }
            else
            {
                GameObject.Find("Player").GetComponent<BonusManager>().wave = true;
            }
        }
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
        {
            if (mi_indexWantedTransformPos == 0)
                mi_indexWantedTransformPos = mt_bellWantedTransformPos.Length - 1;
            else
                mi_indexWantedTransformPos -= 1;
            mt_wantedTransformPosition = mt_bellWantedTransformPos[mi_indexWantedTransformPos];
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (mi_indexWantedTransformPos == mt_bellWantedTransformPos.Length - 1)
                mi_indexWantedTransformPos = 0;
            else
                mi_indexWantedTransformPos += 1;
            mt_wantedTransformPosition = mt_bellWantedTransformPos[mi_indexWantedTransformPos];
        }

        if (Input.GetKey(KeyCode.Space))
        {
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }
    }

    void MoveBell()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, mt_wantedTransformPosition.position, Time.deltaTime * mf_smoothDamping);

        if (mf_bellActionTime >= Time.time)
            this.renderer.material.color = Color.red;
        else
            this.renderer.material.color = Color.white;
    }

    void ApplySpriteRenderer()
    {
        spriteRenderer.sprite = idleSprites[idxIdle];
        timeIdle += Time.deltaTime;
        if (timeIdle > timeBetweenIdle)
        {
            timeIdle = 0.0f;
            idxIdle = (idxIdle + 1) % idleSprites.Length;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (this.renderer.material.color == Color.red && collision.tag != "Player" && !collision.tag.Equals("obstacles") && !collision.gameObject.GetComponent<EnemyScript>().toKill)
        {
            CalculateAccuracy();

            float dist = (10.0f * Vector2.Distance(collision.gameObject.transform.position, mt_wantedTransformPosition.position));
            if (dist > 5.0f)
                dist = 5;
            float percent = (5.0f - dist) / 5.0f;
            float score = 0;

            if (percent < 0.1f)
                score += 0;
            else if (percent < 0.4f)
                score += 60;
            else if (percent < 0.6f)
                score += 150;
            else if (percent < 0.8f)
                score += 220;
            else
                score += 300.0f;

            mf_accuracy += percent;

            if (perfectCombo < 5)
                score *= 2;
            else if (perfectCombo < 10)
                score *= 5;
            else if (perfectCombo < 15)
                score *= 10;

            if (percent >= 0.6f)
            {
                ++perfectCombo;
                ++nbPerfect;
            }
            else
                perfectCombo = 0;

            mf_score += score;

            mf_currentAccuracy = mf_accuracy / mf_instantiateSongCount;
            Debug.Log(percent + ", " + dist);

            Destroy(collision.gameObject);
            
            collision.gameObject.GetComponent<EnemyScript>().kill();
           
            audio.clip = collision.gameObject.GetComponent<EnemyScript>().sonDestruction;
            audio.Play();
        }
    }

    void CalculateAccuracy()
    {
        mf_instantiateSongCount += 1;
        mf_currentAccuracy = mf_accuracy / mf_instantiateSongCount;
    }

    void OnDrawGizmos()
    {
        if (mt_wantedTransformPosition != null)
        {
            Gizmos.DrawSphere(mt_wantedTransformPosition.position, 0.1f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(this.transform.position, 0.1f);
        }
    }
}

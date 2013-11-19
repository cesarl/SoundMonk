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

    public Transform[] mt_bellWantedTransformPos;
    public Transform combo2;


    public Sprite[] idleSprites;

    int mi_indexWantedTransformPos = 0;

    float mf_bellActionTime;
    float mf_instantiateSongCount = 0;
    float timeIdle;
    float timeBetweenIdle = 0.1f;
    public int perfectCombo = 0;

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
        GetInput();
        MoveBell();
        ApplySpriteRenderer();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (mi_indexWantedTransformPos == 0)
                mi_indexWantedTransformPos = mt_bellWantedTransformPos.Length - 1;
            else
                mi_indexWantedTransformPos -= 1;
            mt_wantedTransformPosition = mt_bellWantedTransformPos[mi_indexWantedTransformPos];
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow))
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
        {
            this.renderer.material.color = Color.red;
        }
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
        if (this.renderer.material.color == Color.red && collision.tag != "Player")
        {

            CalculateAccuracy();

            float dist = (10.0f * Vector2.Distance(collision.gameObject.transform.position, mt_wantedTransformPosition.position));
            if (dist > 5.0f)
                dist = 5;
            float percent = (5.0f-dist) / 5.0f;

            if (percent < 0.1f)
            {
                mf_score += 0;
            }
            else if (percent < 0.4f)
            {
                mf_score += 60;
            }
            else if (percent < 0.6f)
            {
                mf_score += 150;
            }
            else if (percent < 0.8f)
            {
                mf_score += 220;
            }
            else
                mf_score += 300.0f;

            mf_accuracy += percent;

            if (percent >= 0.6f)
                ++perfectCombo;
            else
                perfectCombo = 0;

            mf_currentAccuracy = mf_accuracy / mf_instantiateSongCount;
            Debug.Log(percent + ", " + dist);


            Destroy(collision.gameObject);
           
/*            if (perfectCombo == 3)
                Debug.Log("Yeah Super Combo !!!");
            Debug.Log("Combo : " + perfectCombo);*/

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

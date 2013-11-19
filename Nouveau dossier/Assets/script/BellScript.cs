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

    public Sprite[] idleSprites;

    float mf_bellActionTime;
    float mf_instantiateSongCount = 0;
    float timeIdle;
    float timeBetweenIdle = 0.1f;

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
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            mt_wantedTransformPosition = mt_bellWantedTransformPos[0];
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            mt_wantedTransformPosition = mt_bellWantedTransformPos[1];
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            mt_wantedTransformPosition = mt_bellWantedTransformPos[2];
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            mt_wantedTransformPosition = mt_bellWantedTransformPos[3];
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            mt_wantedTransformPosition = mt_bellWantedTransformPos[4];
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            mt_wantedTransformPosition = mt_bellWantedTransformPos[5];
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
            float tf_distanceToPerfect = Vector3.Distance(mt_wantedTransformPosition.position, collision.transform.position);
            float tf_percentDistanceToPerfect = tf_distanceToPerfect / collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
            if (tf_percentDistanceToPerfect > 2)
            {
                mf_score += 0;
                mf_accuracy += 0;
            }
            else if (tf_percentDistanceToPerfect > 1f)
            {
                mf_score += 60;
                mf_accuracy += 0.2f;
            }
            else if (tf_percentDistanceToPerfect > 0.4f)
            {
                mf_score += 150;
                mf_accuracy += 0.5f;
            }
            else if (tf_percentDistanceToPerfect > 0.2f)
            {
                mf_score += 240;
                mf_accuracy += 0.8f;
            }
            else
            {
                mf_score += 300;
                mf_accuracy += 1;
            }
            Debug.Log(collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x);
            mf_currentAccuracy = mf_accuracy / mf_instantiateSongCount;
            Destroy(collision.gameObject);
        }
    }

    void CalculateAccuracy()
    {
        mf_instantiateSongCount += 1;
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

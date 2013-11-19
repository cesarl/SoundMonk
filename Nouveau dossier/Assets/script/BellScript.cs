using UnityEngine;
using System.Collections;

public class BellScript : MonoBehaviour
{
    public Transform player;

    public float mf_score = 0;
    public float mf_accuracy = 0;
    public float mf_currentAccuracy = 1;
    public float mf_smoothDamping = 20;
    public float mf_bellColorationTime = 0.05f;

    public Transform[] mt_bellWantedTransformPos;

    public Sprite[] idleSprites;
    private int idxIdle;
    private SpriteRenderer spriteRenderer;
    private float timeIdle;
    public float timeBetweenIdle = 0.1f;

    float mf_bellActionTime;
    float mf_instantiateSongCount = 0;

    Transform mt_wantedTransformPosition;

    // Use this for initialization
    void Start()
    {
        mt_wantedTransformPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MoveBell();
       
        spriteRenderer.sprite = idleSprites[idxIdle];
        timeIdle += Time.deltaTime;
        if (timeIdle > timeBetweenIdle)
        {
            timeIdle = 0.0f;
            idxIdle = (idxIdle + 1) % idleSprites.Length;
        }

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

    void OnCollisionStay(Collision collision)
    {
        if (this.renderer.material.color == Color.red)
        {
            float tf_distanceToPerfect = Vector3.Distance(mt_wantedTransformPosition.position, collision.transform.position);
            float tf_percentDistanceToPerfect = tf_distanceToPerfect / collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
            if (tf_percentDistanceToPerfect > 1)
            {
                mf_score += 0;
                mf_accuracy += 0;
            }
            else if (tf_percentDistanceToPerfect > 0.5f)
            {
                mf_score += 60;
                mf_accuracy += 0.2f;
            }
            else if (tf_percentDistanceToPerfect > 0.2f)
            {
                mf_score += 150;
                mf_accuracy += 0.5f;
            }
            else if (tf_percentDistanceToPerfect > 0.1f)
            {
                mf_score += 240;
                mf_accuracy += 0.8f;
            }
            else
            {
                mf_score += 300;
                mf_accuracy += 1;
            }

            mf_currentAccuracy = mf_accuracy / mf_instantiateSongCount;
            Destroy(collision.gameObject);
        }

        Debug.Log("oui");
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

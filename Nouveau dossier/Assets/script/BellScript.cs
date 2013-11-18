using UnityEngine;
using System.Collections;

public class BellScript : MonoBehaviour
{
    public Transform player;

    public float mf_score = 0;
    public float mf_accuracy = 0;
    public float mf_currentAccuracy = 1;
    public float mf_smoothDamping = 2;
    public float mf_bellColorationTime = 20f;

    float mf_bellActionTime;
    float mf_instantiateSongCount = 0;

    Vector3 mv_wantedPosition;

    // Use this for initialization
    void Start()
    {
        mv_wantedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MoveBell();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            mv_wantedPosition = player.transform.TransformPoint(new Vector3(-1, -1, this.transform.position.z));
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            mv_wantedPosition = player.transform.TransformPoint(new Vector3(1, -1, this.transform.position.z));
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            mv_wantedPosition = player.transform.TransformPoint(new Vector3(-1, 0, this.transform.position.z));
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            mv_wantedPosition = player.transform.TransformPoint(new Vector3(1, 0, this.transform.position.z));
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            mv_wantedPosition = player.transform.TransformPoint(new Vector3(-1, 1, this.transform.position.z));
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            mv_wantedPosition = player.transform.TransformPoint(new Vector3(1, 1, this.transform.position.z));
            mf_bellActionTime = Time.time + mf_bellColorationTime;
        }
    }

    void MoveBell()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, mv_wantedPosition, Time.deltaTime * mf_smoothDamping);

        if (mf_bellActionTime >= Time.time)
            this.renderer.material.color = Color.red;
        else
            this.renderer.material.color = Color.white;
    }

    void OnCollisionStay(Collision collision)
    {
        if (this.renderer.material.color == Color.red)
        {
            float tf_distanceToPerfect = Vector3.Distance(mv_wantedPosition, collision.transform.position);
            float tf_percentDistanceToPerfect = tf_distanceToPerfect / collision.gameObject.GetComponent<MeshFilter>().mesh.bounds.size.x;
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
    }

    void CalculateAccuracy()
    {
        mf_instantiateSongCount += 1;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(mv_wantedPosition, 0.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 0.1f);
    }
}

using UnityEngine;

public class ProjectileDart : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;
    private bool isTargeted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        if (rb != null)
            ResetRB();

        isTargeted = false;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTarget()
    {
        audioSource.Play();
        StopProjectale();
        isTargeted = true;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.CompareTag("Gun"))
        {
            if (!isTargeted)
            {
                OnTarget();
                transform.SetParent(collision.transform);
            }
            else
            {
                ResetRB();
                transform.SetParent(null);
            }

        }


    }
    void ResetRB()
    {
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = true;
        rb.isKinematic = false;
    }
    void StopProjectale()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

}

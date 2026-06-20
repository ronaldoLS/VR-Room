using UnityEngine;

public class NerfGunTrigger : MonoBehaviour
{
    [SerializeField] private float triggerPullDistance = 0.1f; // The distance the trigger can be pulled

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void active()
    {
        transform.localPosition += new Vector3(0, 0, -triggerPullDistance);

    }
    public void deactive()
    {
        transform.localPosition += new Vector3(0, 0, triggerPullDistance);
    }
}

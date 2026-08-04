using UnityEngine;
using UnityEngine.UI;

public class Pedestal : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rotate(int angle)
    {
        transform.Rotate(Vector3.up, Mathf.Clamp(angle, -360, 360));
    }
}

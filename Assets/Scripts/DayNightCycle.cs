using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private Light sun;

    void Update()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right * -rotation);

    }
}

using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationOffset;

    void Update()
    {
        float currentTime = Clock.Instance.NormalizedDayTime();

        // converte progresso do dia em graus
        float sunRotation = -currentTime * 360f;

        transform.localRotation =
            Quaternion.Euler(
                sunRotation + _rotationOffset.x,
                _rotationOffset.y,
                _rotationOffset.z
            );

    }
}

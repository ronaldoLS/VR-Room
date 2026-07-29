using System;
using UnityEngine;
using UnityEngine.Events;

public class Candle : MonoBehaviour
{
    [SerializeField] private GameObject flame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Serializable] public class FlameEvent : UnityEvent<MonoBehaviour> { }

    public FlameEvent OnFlameLit = new FlameEvent();
    bool isLit = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Flame"))
        {
            if (other.GetComponent<ParticleSystem>().isPlaying)
            {
                flame.GetComponent<ParticleSystem>().Play();

                if (!isLit)
                    OnFlameLit.Invoke(this);

                isLit = true;
            }
        }
    }
}

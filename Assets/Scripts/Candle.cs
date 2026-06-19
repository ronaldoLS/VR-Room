using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] private GameObject flame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flame"))
        {
            if(other.GetComponent<ParticleSystem>().isPlaying)            
                flame.GetComponent<ParticleSystem>().Play();
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Flame"))
        {
            if(other.GetComponent<ParticleSystem>().isPlaying)
            {
                flame.GetComponent<ParticleSystem>().Play();
                Debug.Log("Candle is lit");

            }         

            

        }
    }

}

using UnityEngine;

public class TennisBall : MonoBehaviour
{
    [SerializeField] private AudioClip[] bounces; // Array of AudioClip components for bounce sounds
    private AudioSource audioSource; // AudioSource component to play the bounce sounds
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the TennisBall GameObject
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        // Check if the collided object has the tag "Ground" or "Tennis Racket"
        if (collision.gameObject.CompareTag("Ground") 
            || collision.gameObject.CompareTag("Tennis Racket"))
        {
            if (!audioSource.isPlaying)
            {
                float magnitude = collision.relativeVelocity.magnitude; // Get the magnitude of the collision's relative velocity
                float audioMagnitude = Mathf.Clamp(magnitude / 10f, 0.1f, 1f);
                audioSource.volume = magnitude;

                if (audioMagnitude > 0.6)
                    audioSource.PlayOneShot(bounces[0]);
                else if (audioMagnitude > 0.3)
                    audioSource.PlayOneShot(bounces[1]);
                else if (audioMagnitude > 0.15)
                    audioSource.PlayOneShot(bounces[2]);
                else
                    audioSource.PlayOneShot(bounces[3]);
            }
        }
        
    }
}

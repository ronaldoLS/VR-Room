using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Platter; // Reference to the Platter GameObject
    [SerializeField] private GameObject Handle; // Reference to the Handle GameObject
    private float rotationSpeed = 10f; // Speed at which the Platter rotates
    [SerializeField] private AudioClip[] musicTracks; // Array of AudioClip components for music tracks
    private AudioSource audioSource; // AudioSource component to play the music tracks
    int randomIndex = 0; // Variable to store the randomly generated index for selecting a music track

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the RecordPlayer GameObject
        randomIndex = Random.Range(0, musicTracks.Length); // Generate a random index to select a music track
        audioSource.volume = 0.8f; // Set the volume of the AudioSource to 80%
        audioSource.clip = musicTracks[randomIndex]; // Set the randomly selected music track as the clip
        audioSource.Play(); // Start playing the music track
    }

    // Update is called once per frame
    void Update()
    {
        Platter.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed); // Rotate the Platter GameObject around the Y-axis
    }
}

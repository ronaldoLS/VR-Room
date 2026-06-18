using System.Collections;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Platter; // Reference to the Platter GameObject
    [SerializeField] private GameObject Handle; // Reference to the Handle GameObject
    private float rotationSpeed = 10f; // Speed at which the Platter rotates
    [SerializeField] private AudioClip[] musicTracks; // Array of AudioClip components for music tracks
    private AudioSource audioSource; // AudioSource component to play the music tracks
    int randomIndex = 0; // Variable to store the randomly generated index for selecting a music track
    private Coroutine musicCoroutine; // Coroutine to handle music playback
    public bool isPlayingPlaylist = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the RecordPlayer GameObject
        randomIndex = Random.Range(0, musicTracks.Length); // Generate a random index to select a music track
        audioSource.clip = musicTracks[randomIndex]; // Set the randomly selected music track as the clip
        StartPlaylist(); // Start playing the music playlist
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying && Platter != null)
            Platter.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed); // Rotate the Platter GameObject around the Y-axis
    }
    void RandomMusic()
    {
        int currentRandomIndex = randomIndex;
        do
            randomIndex = Random.Range(0, musicTracks.Length); // Generate a new random index to select a music track
        while (currentRandomIndex == randomIndex && musicTracks.Length > 1);


        audioSource.clip = musicTracks[randomIndex]; // Set the newly selected music track as the clip
    }

    void StartPlaylist()
    {

        if (musicCoroutine != null)
            StopCoroutine(musicCoroutine);

        isPlayingPlaylist = true;
        musicCoroutine = StartCoroutine(PlayMusicPlaylist());

    }
    public void StopPlaylist()
    {
        isPlayingPlaylist = false;
        if (musicCoroutine != null) StopCoroutine(musicCoroutine);
        audioSource.Stop();
    }
    IEnumerator PlayMusicPlaylist()
    {
        while (isPlayingPlaylist)
        {

            RandomMusic();
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);

            // O loop while vai reiniciar e escolher a próxima música automaticamente
        }
    }
}

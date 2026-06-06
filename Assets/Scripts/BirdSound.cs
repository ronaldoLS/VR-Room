using System.Collections;
using UnityEngine;

public class BirdSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] birdSounds;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(PlayRandomBirdSound());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioClip RandomBirdClip()
    {
        return birdSounds[Random.Range(0, birdSounds.Length)];
    }
    public void SetBirdSound(AudioClip clip)
    {
        audioSource.clip = clip;
    }
    IEnumerator PlayRandomBirdSound()
    {
        while (true)
        {

            SetBirdSound(RandomBirdClip());
            audioSource.volume = Random.Range(0.1f, 1f);
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length + Random.Range(4f, 10f));
        }
    }

}

using UnityEngine;

public class Notebook : MonoBehaviour
{
    [SerializeField] private float playAngle = -15f;
    [SerializeField] private float resetAngle = -5f;
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;
    private HingeJoint hingeJoint;
    private bool playedAudio = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hingeJoint = GetComponentInChildren<HingeJoint>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPlaying() && hingeJoint.angle <= playAngle)
        {
            if (playedAudio)
                return;

            PlayAudio();
        }

        if (IsPlaying() && hingeJoint.angle >= resetAngle && hingeJoint.angle <= 0)
        {
            PauseAudio();
            playedAudio = false;
        }


    }

    public void PlayAudio()
    {
        if (audioSource == null)
            return;

        audioSource.Play();
        playedAudio = true;
    }
    public void PauseAudio()
    {
        if (IsPlaying())
            audioSource.Pause();
    }
    public void RestartAudio()
    {
        if (IsPlaying())
            return;

        StopAudio();
        PlayAudio();
    }
    public void StopAudio()
    {
        audioSource.Stop();
        playedAudio = false;
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }



}

using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomMusic();
        audioSource.loop = false;
    }

    void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, musicClips.Length);
        audioSource.clip = musicClips[randomIndex];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }
}

using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource audioSource;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            created = true;
            PlayRandomMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, musicClips.Length);
        audioSource.clip = musicClips[randomIndex];
        audioSource.volume = 0.6f;
        audioSource.loop = true; 
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

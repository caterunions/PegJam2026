using UnityEngine;

public class audioscript : MonoBehaviour
{
    [Header("-----audioscript -----")]
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource effectSource;

    
    [Header("-----AudioClips -----")]
    public AudioClip backgroundMusic;
    public AudioClip Explosion;
    public AudioClip goblinsilly;
    public AudioClip lasershooting;
    public AudioClip collecting;
    public AudioClip Mechinenoise;
    public AudioClip Alarmsound;
    public AudioClip dooropening;
    public AudioClip Intromusic;



    private void Start()
    {
        MusicSource.clip = backgroundMusic;
        MusicSource.Play();
    }

    public void playsfx(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void explode()
    {

    }

    public void gobtime()
    {

    }

    public void lasershot()
    {

    }

    public void collect()
    {

    }

    public void intro()
    {

    }

}

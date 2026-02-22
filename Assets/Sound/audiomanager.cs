using UnityEngine;

public class audioscriot : MonoBehaviour
{
    [Header("-----audioscriot -----")]
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource effectSource;


    [Header("-----AudioClips -----")]
    public AudioClip backgroundMusic;
    public AudioClip Explosion;
    public AudioClip goblinsilly;
    public AudioClip lasershooting;
    public AudioClip collecting;


    private void Start()
    {
        MusicSource.clip = backgroundMusic;
        MusicSource.Play();
    }

    public void playsfx(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }


}

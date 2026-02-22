using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [Header("----- AudioScript -----")]
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource effectSource;

    [Header("----- AudioClips -----")]
    public AudioClip backgroundMusic;
    public AudioClip Explosion;
    public AudioClip goblinsilly;
    public AudioClip lasershooting;
    public AudioClip collecting;
    public AudioClip Mechinenoise;
    public AudioClip Alarmsound;
    public AudioClip dooropening;
    public AudioClip Intromusic;

    // ── Music Methods ────────────────────────────────────────────────

    public void PlayBackgroundMusic()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlayIntroMusic()
    {
        PlayMusic(Intromusic);
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }

    // ── SFX Methods ──────────────────────────────────────────────────

    public void PlayExplosionSound()
    {
        PlaySFX(Explosion);
    }

    public void PlayGoblinSound()
    {
        PlaySFX(goblinsilly);
    }

    public void PlayLaserSound()
    {
        effectSource.PlayOneShot(lasershooting, 0.3f);
    }

    public void PlayCollectSound()
    {
        PlaySFX(collecting);
    }

    public void PlayMachineSound()
    {
        effectSource.PlayOneShot(Mechinenoise, 0.5f);
    }

    public void PlayAlarmSound()
    {
        PlaySFX(Alarmsound);
    }

    public void PlayDoorSound()
    {
        PlaySFX(dooropening);
    }

    // ── Compound Methods ─────────────────────────────────────────────

    public void PlayProcessOreSound()
    {
        PlaySFX(Mechinenoise);
    }

    // ── Internal Helpers ─────────────────────────────────────────────

    private void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();

        if (clip == null)
        {
            Debug.LogWarning("[AudioScript] Music clip is null.");
            return;
        }
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("[AudioScript] SFX clip is null.");
            return;
        }

        effectSource.PlayOneShot(clip);
    }

    // ── Lifecycle ────────────────────────────────────────────────────

    private void OnDestroy()
    {
        
    }
}
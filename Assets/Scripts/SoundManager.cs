using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource bgmSource;

    [Header("Sound Clips")]
    public AudioClip shootClip;
    public AudioClip shieldClip;
    public AudioClip bossDefeatedClip;
    public AudioClip gameOverClip;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayShootSound() => PlaySound(shootClip);
    public void PlayShieldSound() => PlaySound(shieldClip);
    public void PlayBossDefeatedSound() => PlaySound(bossDefeatedClip);
    public void PlayGameOverSound() => PlayBGM(gameOverClip);

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
            sfxSource.PlayOneShot(clip);
    }

    private void PlayBGM(AudioClip bgmClip)
    {
        if (bgmSource != null && bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    private void StopBGM()
    {
        if (bgmSource != null)
            bgmSource.Stop();
    }
}

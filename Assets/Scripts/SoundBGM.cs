using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBGM : MonoBehaviour
{
    public static SoundBGM Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] private AudioSource effectSource;

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
    public void StopAllSounds()
    {
        effectSource.Stop();
    }
}

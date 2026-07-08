using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource sfxSource;

    [Header("SFX")]
    public AudioClip jumpClip;
    public AudioClip coinClip;
    public AudioClip doorClip;
    public AudioClip buttonClip;
    public AudioClip gameOverClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpClip);
    }

    public void PlayCoin()
    {
        sfxSource.PlayOneShot(coinClip);
    }

    public void PlayDoor()
    {
        sfxSource.PlayOneShot(doorClip);
    }

    public void PlayButton()
    {
        sfxSource.PlayOneShot(buttonClip);
    }

    public void PlayGameOver()
    {
        sfxSource.PlayOneShot(gameOverClip);
    }
}

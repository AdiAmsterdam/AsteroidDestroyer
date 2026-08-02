using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //maybe adding an audio chanel enum to make it easier to produce sounds
    public static AudioManager audioManager;
    
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource EngineSource;
    
    void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (audioManager != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void PlaySFX(AudioClip clip)
    {
        if(!SFXSource || !clip) return; 
        SFXSource.pitch = Random.Range(0.95f, 1.2f);
        SFXSource.PlayOneShot(clip);
    }

    public void PlayEngineSound(AudioClip clip)
    {
        if (!EngineSource || !clip)
            return;
        
        if (EngineSource.clip != clip)
            EngineSource.clip = clip;

        EngineSource.loop = true;
        EngineSource.volume = 0.5f;

        if (!EngineSource.isPlaying)
            EngineSource.Play();
    }

    public void StopEngineSound()
    {
        if (EngineSource.isPlaying)
            EngineSource.Stop();
    }
}
using DefaultNamespace;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //maybe adding an audio chanel enum to make it easier to produce sounds
    public static AudioManager audioManager;
    
    [SerializeField] private AudioSource gunSource;
    [SerializeField] private AudioSource engineSource;
    
    [SerializeField] private AudioSource laserSwordSource;
    [SerializeField] private AudioSource laserSwordLoopSource;
    
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

    public void PlaySFX(AudioChannel channel, AudioClip clip)
    {
        switch (channel)
        {
            case AudioChannel.Gun:
                PlayGunSound(clip);
                break;
            case AudioChannel.LaserSword:
                PlayLaserSwordSound(clip);
                break;
        }
    }

    private void PlayLoop(AudioSource source, AudioClip clip, float volume)
    {
        if (!source || !clip)
            return;
        
        if (source.clip != clip)
            source.clip = clip;

        source.loop = true;
        source.volume = volume;

        if (!source.isPlaying)
            source.Play();
    }

    private void StopLoop(AudioSource source)
    {
        if (source && source.isPlaying)
            source.Stop();
    }
    
    private void PlayGunSound(AudioClip clip)
    {
        if(!gunSource || !clip) return; 
        gunSource.pitch = Random.Range(0.95f, 1.2f);
        gunSource.PlayOneShot(clip);
    }

    public void PlayEngineSound(AudioClip clip)
    {
        PlayLoop(engineSource, clip, 0.5f);
    }

    public void StopEngineSound()
    {
        StopLoop(engineSource);
    }

    private void PlayLaserSwordSound(AudioClip clip)
    {
        if(!laserSwordSource || !clip) return; 
        laserSwordSource.PlayOneShot(clip);
    }
    
    public void PlayLaserSwordLoop(AudioClip clip)
    {
        PlayLoop(laserSwordLoopSource, clip, 0.3f);
    }

    public void StopLaserSwordLoop()
    {
        StopLoop(laserSwordLoopSource);
    }
}
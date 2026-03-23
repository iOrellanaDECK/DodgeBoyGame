using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer audioMixer;
    public AudioSource musicSource;
    public AudioSource sfxSource;

   
    public AudioClip menuMusic;
    public AudioClip menuSfx;
    public AudioClip gameMusic;

   
    public AudioClip collisionSFX;

   
    public AudioClip[] ambientExplosions;
    public float ambientIntervalMin = 3f;
    public float ambientIntervalMax = 7f;

    public AudioClip[] debrisGroundSFX;

    private float savedMusicVolume = 1f;
    private float savedSFXVolume = 1f;

    private Coroutine ambientCoroutine;

    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // ------------------------------------------------------------
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        switch (sceneName)
        {
            case "MainMenu":
                PlayMusic(menuMusic);
                PlaySFX(menuSfx);
                break;

            case "GameScene":
                StopSfx();
                PlayMusic(gameMusic);

                
                if (ambientCoroutine != null)
                {
                    StopCoroutine(ambientCoroutine);
                }
                ambientCoroutine = StartCoroutine(PlayAmbientExplosions());
                break;
        }
    }

    
    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
    public void StopSfx()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log("Música: " + volume);
        savedMusicVolume = volume;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        savedSFXVolume = volume;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
    }

    public void MuteAll(bool mute)
    {
            audioMixer.SetFloat("MusicVolume", mute ? -80f : Mathf.Log10(savedMusicVolume) * 20);
            audioMixer.SetFloat("SFXVolume", mute ? -80f : Mathf.Log10(savedSFXVolume) * 20);
    }


    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    public void PlayRandomDebrisGroundSFX()
    {
        if (debrisGroundSFX.Length > 0)
        {
            int index = Random.Range(0, debrisGroundSFX.Length);
            PlaySFX(debrisGroundSFX[index]);
        }
    }

    private IEnumerator PlayAmbientExplosions()
    {
        while (true)
        {
            float waitTime = Random.Range(ambientIntervalMin, ambientIntervalMax);
            yield return new WaitForSeconds(waitTime);

            if (ambientExplosions.Length > 0)
            {
                int index = Random.Range(0, ambientExplosions.Length);
                PlaySFX(ambientExplosions[index]);
            }
        }
    }
}

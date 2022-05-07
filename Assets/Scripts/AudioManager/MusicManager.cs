using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager INSTANCE;

    public AudioClip Song;
    public bool loop;

    [Range(0f, 1f)] public float volume;

    private AudioSource audioSource;


    private void Awake()
    {
        if (INSTANCE != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            INSTANCE = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = Song;
        audioSource.volume = volume;
        audioSource.loop = loop;
        playSong();
    }

    private void Update()
    {
        audioSource.volume = volume;
    }

    public void playSong()
    {
        audioSource.Play();
    }
}

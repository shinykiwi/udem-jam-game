using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] songs;
    public float volume;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    public void ChangeSong(int songIndex)
    {
        audioSource.clip = songs[songIndex];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume= volume;
        if (!audioSource.isPlaying && audioSource.time == 0)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }
}

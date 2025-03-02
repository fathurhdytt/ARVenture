using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source----------")]
    [SerializeField] private AudioSource musicSource; // Gunakan SerializeField agar terlihat di Inspector

    [Header("----------Audio Clip----------")]
    public AudioClip background;

    void Start()
    {
        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.loop = true; // Aktifkan loop
            musicSource.Play();
        }
    }
}

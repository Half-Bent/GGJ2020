using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicObject : MonoBehaviour
{
    public AudioClip music;
    public float volume = 0.75f;
    public AudioSource audioSource;


    private void Start()
    {
        audioSource.clip = music;
        audioSource.volume = volume;
        audioSource.Play();
    }
}

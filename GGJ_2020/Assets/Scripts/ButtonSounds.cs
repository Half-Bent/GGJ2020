using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip onHighlightedSound;

    private AudioSource audiosource;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audiosource.volume = 0.25f;
        audiosource.clip = onHighlightedSound;
        audiosource.Play();
    }
}

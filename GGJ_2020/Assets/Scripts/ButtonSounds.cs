using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip onHighlightedSound;
    public AudioClip onPressedSound;

    private AudioSource audiosource;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audiosource.clip = onHighlightedSound;
        audiosource.Play();
    }

    public void OnPressed()
    {
        audiosource.clip = onPressedSound;
        audiosource.Play();
    }
}

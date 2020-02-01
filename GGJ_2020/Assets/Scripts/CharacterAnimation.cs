using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterAnimation : MonoBehaviour
{ 
    public List<AudioClip> swingSounds;
    public List<AudioClip> hitSounds;
    public AudioClip footstepSound;

    private Animator myAnim;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private float footstepBreakTime = 0f;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AnimateMovement(Vector3 movement)
    {
        if (movement.x != 0)
            spriteRenderer.flipX = movement.x > 0 ? true : false;

        myAnim.SetFloat("xSpeed", movement.x);
        myAnim.SetFloat("ySpeed", movement.y);

        // Cool spaghetti for sprite facing side determination 
        if (movement.y > movement.x)
        {
            myAnim.SetBool("facingUp", true);
            myAnim.SetBool("facingDown", false);
            myAnim.SetBool("facingSide", false);
        }

        if (movement.y < movement.x)
        {
            myAnim.SetBool("facingUp", false);
            myAnim.SetBool("facingDown", true);
            myAnim.SetBool("facingSide", false);
        }

        if (movement.x != 0 && movement.y == 0)
        {
            myAnim.SetBool("facingUp", false);
            myAnim.SetBool("facingDown", false);
            myAnim.SetBool("facingSide", true);
        }

        if (footstepBreakTime <= 0 && movement.magnitude > 0.1f)
        {
            footstepBreakTime = 0.25f;
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.volume = 0.25f;
            audioSource.clip = footstepSound;
            audioSource.Play();
        }

        if (footstepBreakTime > 0)
            footstepBreakTime -= Time.deltaTime;
    }

    public void AnimateRepair()
    {
        audioSource.pitch = 1f;
        audioSource.volume = 1f;
        audioSource.clip = swingSounds[Random.Range(0, swingSounds.Count)];
        audioSource.Play();

        myAnim.SetTrigger("repair");
    }
}

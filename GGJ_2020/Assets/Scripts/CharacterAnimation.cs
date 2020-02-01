using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator myAnim;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void AnimateMovement(Vector3 movement)
    {
        spriteRenderer.flipX = movement.x < 0 ? true : false;

        myAnim.SetFloat("xSpeed", movement.x);
        myAnim.SetFloat("ySpeed", movement.y);
    }

    public void AnimateRepair()
    {
        myAnim.SetTrigger("repair");
    }
}

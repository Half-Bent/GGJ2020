using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator myAnim;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        myAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        
    }

    public void AnimateRepair()
    {
        myAnim.SetTrigger("repair");
    }
}

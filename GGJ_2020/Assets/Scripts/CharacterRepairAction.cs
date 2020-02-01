using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CharacterRepairAction : MonoBehaviour
{
    CharacterMovement movement;
    CharacterAnimation anim;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<CharacterMovement>();
        anim = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.GetController == XboxController.First){
            if(XCI.GetButtonDown(XboxButton.A, movement.GetController)){
                doAction();
            }
        }else{
            if(Input.GetKeyDown(KeyCode.Space))
                doAction();
        }
    }

    private void doAction(){
        Debug.Log("action");
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3);
            if(hits.Length > 0){
                for(int i = 0; i < hits.Length; i++){
                    if(!hits[i].tag.Contains("Repairable"))
                        continue;
                    if(Vector2.Distance( hits[i].transform.position, transform.position) < 1){
                        hits[i].GetComponent<RepairableObject>().Reapir();
                    }
                    
                }
            }
        anim.AnimateRepair();
    }

}

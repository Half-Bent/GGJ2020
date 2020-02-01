using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableObject : MonoBehaviour
{

    public Sprite RepairImage;
    public Animator anim;
    public bool Repaired = false;
    public RoomManager manager;

    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
            manager = FindObjectOfType<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reapir(){
        if(!Repaired){
            Debug.Log("repairing");
            if (anim != null)
                anim.SetTrigger("fix");
            else
                GetComponent<SpriteRenderer>().sprite = RepairImage;
            Repaired = true;
            manager.RepairedObjects++;
        }
    }
}

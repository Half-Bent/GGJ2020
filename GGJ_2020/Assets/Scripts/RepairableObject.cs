using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableObject : MonoBehaviour
{

    public Sprite RepairImage;
    public bool Repaired = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reapir(){
        if(!Repaired){
            GetComponent<SpriteRenderer>().sprite = RepairImage;
            Repaired = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRepairAction : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3);
            if(hits.Length > 0){
                for(int i = 0; i < hits.Length; i++){
                    if(!hits[i].tag.Contains("Repairable"))
                        continue;
                    if(Vector3.Distance( hits[i].transform.position, transform.position) < 1){
                        hits[i].GetComponent<RepairableObject>().Reapir();
                    }
                    
                }
            }

        }
    }

}
